using System.Numerics;

namespace Raytracer
{
    public class HitRecord
    {

        public float t; // the distance along the ray where the ray hit
        public Vector3 p; // the location of the point where the ray hit
        public Vector3 normal; //  the normal vector of the point

        public void Update(float t, Vector3 p, Vector3 normal)
        {
            this.t = t;
            this.p = p;
            this.normal = normal;
        }

        public void Update(HitRecord r)
        {
            this.t = r.t;
            this.p = r.p;
            this.normal = r.normal;
        }

    }
}