using System.Numerics;

namespace Raytracer
{
    public abstract class Hitable
    {
        public abstract bool Hit(Ray r, float tMin, float tMax, HitRecord record);
    }
}