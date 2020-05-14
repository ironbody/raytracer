using System;
using System.Numerics;

namespace Raytracer
{
    public class Sphere : Hitable
    {
        private Vector3 center;
        private float radius;

        public Vector3 Center { get => center; set => center = value; }
        public float Radius { get => radius; set => radius = value; }

        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override bool Hit(Ray r, float tMin, float tMax, HitRecord record)
        {
            // this is magic and it didn't really make sense
            // basically it solves a quadratic equation to see if r hits the sphere
            // read chapter 4 of "Ray Tracing in One Weekend" by Peter Shirley to learn more
            // the code is slightly modified from chapter 5

            Vector3 oc = r.Origin - Center;
            float a = Vector3.Dot(r.Direction, r.Direction);
            float b = 2f * Vector3.Dot(oc, r.Direction);
            float c = Vector3.Dot(oc, oc) - Radius * Radius;
            double discriminant = b * b - (4 * a * c);

            if (discriminant > 0)
            {
                // temp is the value of t where it intersects with the sphere
                float temp = (-b - (float) Math.Sqrt(discriminant)) / (2 * a);
                if (temp < tMax && temp > tMin)
                {
                    var t = temp;
                    var p = r.PointAt(t);
                    var normal = (p - center) / radius;
                    record.Update(t, p, normal);
                    return true;
                }

                temp = (-b + (float) Math.Sqrt(discriminant)) / (2 * a);
                if (temp < tMax && temp > tMin)
                {
                    var t = temp;
                    var p = r.PointAt(t);
                    var normal = (p - center) / radius;
                    record.Update(t, p, normal);
                    return true;
                }
            }

            return false;
        }
    }
}