using System.Numerics;

namespace Raytracer
{
    public class Ray
    {
        private Vector3 origin;
        private Vector3 direction;

        public Vector3 Origin { get => origin; set => origin = value; }
        public Vector3 Direction { get => direction; set => direction = value; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Vector3 PointAt(float t) => origin + t * direction; // t moves the point along the ray
        
    }
}