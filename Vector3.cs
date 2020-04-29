// namespace Raytracer
// {
//     public class Vector3
//     {
//         private double x;
//         private double y;
//         private double z;

//         public double X { get => x; set => x = value; }
//         public double Y { get => y; set => y = value; }
//         public double Z { get => z; set => z = value; }
//         public double R { get => x; set => x = value; }
//         public double G { get => y; set => y = value; }
//         public double B { get => z; set => z = value; }

//         public Vector3(double x, double y, double z)
//         {
//             this.x = x;
//             this.y = y;
//             this.z = z;
//         }

//         public static Vector3 operator +(Vector3 a) => a;
//         public static Vector3 operator -(Vector3 a) => new Vector3(-a.X, -a.Y, -a.Z);

//         public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
//         public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
//         public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

//     }
// }