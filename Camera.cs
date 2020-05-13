using System;
using System.Numerics;

namespace Raytracer
{
    public class Camera
    {
        Vector3 origin;
        Vector3 lowLeft; // lower left corner of the view

        // it's not really explained so far what these two vectors mean
        Vector3 horizontal;
        Vector3 vertical;

        public Vector3 Origin { get => origin; set => origin = value; }
        public Vector3 LowLeft { get => lowLeft; set => lowLeft = value; }
        public Vector3 Horizontal { get => horizontal; set => horizontal = value; }
        public Vector3 Vertical { get => vertical; set => vertical = value; }

        public Camera()
        {
            origin = new Vector3(0);
            lowLeft = new Vector3(-2, -1, -1);
            horizontal = new Vector3(4, 0, 0);
            vertical = new Vector3(0, 2, 0);
        }

        public Ray GetRay(float u, float v)
        {
            return new Ray(origin, lowLeft + u * horizontal + v * vertical - origin);
        }
    }
}