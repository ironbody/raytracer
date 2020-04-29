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

            var lowLeft = new Vector3(-2f, -1f, -1f);
            var hor = new Vector3(4f, 0f, 0f);
            var ver = new Vector3(0f, 2f, 0f);
            var origin = new Vector3(0f);

            using(var image = new Image<Rgba32>(width, height))
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    for (int i = 0; i < width; i++)
                    {
                        var u = (float) i / (float) width;
                        var v = 1 - (float) j / (float) height;

                        var r = new Ray(origin, lowLeft + u * hor + v * ver);
                        var col = Color(r);

                        image[i, j] = new Rgba32(col);

                    }
                }

                image.Save("images/second.png");
            }

            Vector3 Color(Ray r)
            {
                if (hitSphere(new Vector3(0f, 0f, 1f), 0.5f, r))
                {
                    return new Vector3(1f, 0f, 0f);
                }
                var unitDirection = Vector3.Normalize(r.Direction); // makes vector go between -1 and 1
                var t = 0.5f * (unitDirection.Y + 1.0f); // scales vector so it goes between 0 and 1
                return (1 - t) * new Vector3(1f) + t * new Vector3(0.5f, 0.7f, 1.0f); // linearly interpolates color 
            }

            bool hitSphere(Vector3 center, float radius, Ray r)
            {
                // this is magic and it didn't really make sense
                // read chapter 4 of "Ray Tracing in One Weekend" by Peter Shirley to learn more

                var oc = r.Origin - center;
                var a = Vector3.Dot(r.Direction, r.Direction);
                var b = 2f * Vector3.Dot(oc, r.Direction);
                var c = Vector3.Dot(oc, oc) - radius * radius;
                float discriminant = b * b - 4 * a * c;
                return discriminant > 0;
            }
        }
    }
}