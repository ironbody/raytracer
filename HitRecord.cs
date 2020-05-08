using System.Numerics;

namespace Raytracer
{
    public class HitRecord
    {

        public float t;
        public Vector3 p;
        public Vector3 normal;

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