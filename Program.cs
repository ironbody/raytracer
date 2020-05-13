using System;
using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Raytracer
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = 200;
            var height = 100;
            var samples = 100;

            var camera = new Camera();
            var rand = new Random();

            var world = new HitableList();
            world.Add(new Sphere(
                new Vector3(0, 0, -1),
                0.5f
            ));
            world.Add(new Sphere(
                new Vector3(0, -100.5f, -1),
                100f
            ));

            using(var image = new Image<Rgba32>(width, height))
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    for (int i = 0; i < width; i++)
                    {
                        var col = new Vector3(0);

                        for (int s = 0; s < samples; s++)
                        {
                            // the horizontal distance from the origin as a float between 0 and 1
                            // with a random number between 0 and 1 added to it for each sample
                            var u = (i + (float) rand.NextDouble()) / (float) width;

                            // the vertical distance from the origin as a float between 0 and 1
                            // with a random number between 0 and 1 added to it for each sample
                            var v = 1 - ((j + (float) rand.NextDouble()) / (float) height);

                            var r = camera.GetRay(u, v);
                            col += Color(r, world);

                        }

                        col /= (float) samples;

                        image[i, j] = new Rgba32(col);
                    }
                }

                image.Save("images/test7.png");

            }

            Vector3 Color(Ray r, Hitable world)
            {
                var rec = new HitRecord();

                if (world.Hit(r, 0.0f, float.MaxValue, rec))
                {
                    // System.Console.WriteLine(new Vector3(rec.normal.X + 1, rec.normal.Y + 1, rec.normal.Z + 1));
                    var normal = Vector3.Normalize(rec.normal);
                    // Transfroms the record's normal vector to be between 0 and 1 and then returns its XYZ as RGB
                    return 0.5f * new Vector3(normal.X + 1, normal.Y + 1, normal.Z + 1);
                }
                else
                {
                    var unitDirection = Vector3.Normalize(r.Direction); // makes vector go between -1 and 1
                    var t = 0.5f * (unitDirection.Y + 1.0f); // scales vector so it goes between 0 and 1
                    return (1 - t) * new Vector3(1f) + t * new Vector3(0.5f, 0.7f, 1.0f); // linearly interpolates color 
                }
            }
        }
    }
}