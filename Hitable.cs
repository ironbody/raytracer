using System.Numerics;

namespace Raytracer
{
    public struct HitRecord
    {
        public float t;
        public Vector3 p;
        public Vector3 normal;

        public HitRecord(float t, Vector3 p, Vector3 normal)
        {
            this.t = t;
            this.p = p;
            this.normal = normal;
        }

        public void Update(float t, Vector3 p, Vector3 normal)
        {
            this.t = t;
            this.p = p;
            this.normal = normal;
        }
    }

    public abstract class Hitable
    {
        public abstract bool Hit(Ray r, float tMin, float tMax, HitRecord record);
    }
}