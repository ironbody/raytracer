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
            var width = 100 * 2 * 2;
            var height = 100 * 2 * 1;

            var lowLeft = new Vector3(-2f, -1f, -1f); // lower left corner of the view
            var hor = new Vector3(4f, 0f, 0f);
            var ver = new Vector3(0f, 2f, 0f);
            var origin = new Vector3(0f);

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
                        var u = (float) i / (float) width; // the width as a float between 0 and 1
                        var v = 1 - (float) j / (float) height; // the height as a float between 0 and 1

                        var r = new Ray(origin, lowLeft + u * hor + v * ver);
                        var col = Color(r,world);

                        image[i, j] = new Rgba32(col);

                    }
                }

                image.Save("images/lsdkjgf.png");
            }

            Vector3 Color(Ray r, Hitable world)
            {
                var rec = new HitRecord();

                if (world.Hit(r, 0.0f, float.MaxValue, rec))
                {
                    // Transfroms the record's normal vector to be between 0 and 1 and then returns its XYZ as RGB
                    return 0.5f * new Vector3(rec.normal.X + 1, rec.normal.Y + 1, rec.normal.Z + 1);
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