using System.Numerics;

namespace Raytracer
{
    public class HitRecord
    {

        private float t; // the distance along the ray where the ray hit
        private Vector3 p; // the location of the point where the ray hit
        private Vector3 normal; // the normal vector of the point
        private Material material;

        public float T { get => t; }
        public Vector3 P { get => p;}
        public Vector3 Normal { get => normal;}
        public Material Material { get => material;}

        public void Update(float t, Vector3 p, Vector3 normal)
        {
            this.t = t;
            this.p = p;
            this.normal = normal;
        }

        public void Update(HitRecord r)
        {
            this.t = r.T;
            this.p = r.P;
            this.normal = r.Normal;
        }

    }
}