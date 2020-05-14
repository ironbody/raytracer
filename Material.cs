using System.Numerics;

namespace Raytracer
{
    public abstract class Material
    {
        public abstract bool Scatter(Ray rIn, HitRecord record, Vector3 attenuation, Ray scattered);
    }
}