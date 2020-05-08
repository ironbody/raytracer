using System.Collections.Generic;
using System.Numerics;

namespace Raytracer
{
    public class HitableList : Hitable
    {
        List<Hitable> list = new List<Hitable>();

        public List<Hitable> List { get => list; set => list = value; }

        public override bool Hit(Ray r, float tMin, float tMax, HitRecord record)
        {
            var tempRec = new HitRecord();
            var hitAnything = false;
            var closestSoFar = tMax;

            foreach (var h in list)
            {
                if (h.Hit(r, tMin, closestSoFar, tempRec))
                {
                    hitAnything = true;
                    closestSoFar = tempRec.t;
                    record.Update(tempRec);
                }
            }
            return hitAnything;
        }

        public void Add(Hitable h) => list.Add(h);
    }
}