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

                        // gamma correction
                        // basically fixes the color
                        // this is gamma 2 so you raise the color to the power 1/gamma which in this case means sqrt
                        col = new Vector3((float) Math.Sqrt(col.X), (float) Math.Sqrt(col.Y), (float) Math.Sqrt(col.Z));

                        image[i, j] = new Rgba32(col);
                    }
                }

                image.Save("images/gammacorr.png");

            }

            Vector3 Color(Ray r, Hitable world)
            {
                var rec = new HitRecord();

                if (world.Hit(r, 0.001f, float.MaxValue, rec))
                {
                    // generates a random point in a sphere that is tangent to the hitpoint
                    var target = rec.p + rec.normal + RandomInUnitSphere();

                    // sends out a new ray in the direction of the target from the hitpoint
                    // returns when one of the subsequent rays either hits the sky or the t values become so close that they're basically zero
                    // the 0.5 means that 50% of the rays are absorbed into the material
                    return 0.5f * Color(new Ray(rec.p, target - rec.p), world);
                }
                else
                {
                    // this creates the sky
                    var unitDirection = Vector3.Normalize(r.Direction); // makes direction vector go between -1 and 1
                    var t = 0.5f * (unitDirection.Y + 1.0f); // scales vector so it goes between 0 and 1
                    return (1 - t) * new Vector3(1f) + t * new Vector3(0.5f, 0.7f, 1.0f); // linearly interpolates color 
                }
            }

            Vector3 RandomInUnitSphere()
            {
                var p = new Vector3();

                do
                {
                    // This generates a random point with XYZ between -1 and 1
                    p = 2 * new Vector3((float) rand.NextDouble(), (float) rand.NextDouble(), (float) rand.NextDouble()) - new Vector3(1);
                } while (p.LengthSquared() >= 1f);

                return p;
            }
        }
    }
}