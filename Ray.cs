using System.Numerics;

namespace Raytracer
{
    public class Ray
    {
        private Vector3 origin;
        private Vector3 direction;

        public Vector3 Origin { get => origin; set => origin = value; }
        public Vector3 Direction { get => direction; set => direction = value; }

        public Ray(Vector3 a, Vector3 b)
        {
            this.origin = a;
            this.direction = b;
        }

        Vector3 PointAt(float t) => origin + t * direction; // t moves the point along the ray
        
    }
}