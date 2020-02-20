/*
    Vector math library
*/
using System;

namespace XeonUtil.Math.Vector
{
    public class Vec2D : Tuple<double, double>
    {
        public double X { get => Item1; }
        public double Y { get => Item2; }
        public Vec2D(double x, double y) : base(x, y) { }
        public Vec2D((double x, double y) tuple) : base(tuple.x, tuple.y) { }
        public static Vec2D operator +(Vec2D a, Vec2D b) => new Vec2D(a.X + b.X, a.Y + b.Y);
        public static Vec2D operator -(Vec2D a, Vec2D b) => new Vec2D(a.X - b.X, a.Y - b.Y);
        public static Vec2D operator *(Vec2D a, Vec2D b) => new Vec2D(a.X * b.X, a.Y * b.Y);
        public static Vec2D operator *(Vec2D a, double b) => new Vec2D(a.X * b, a.Y * b);
        public static Vec2D operator *(double a, Vec2D b) => new Vec2D(a * b.X, a * b.Y);
        public static Vec2D operator /(Vec2D a, Vec2D b) => new Vec2D(a.X / b.X, a.Y / b.Y);
        public static Vec2D operator /(Vec2D a, double b) => new Vec2D(a.X / b, a.Y / b);
        public static Vec2D operator /(double a, Vec2D b) => new Vec2D(a / b.X, a / b.Y);
        public static bool operator ==(Vec2D a, Vec2D b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vec2D a, Vec2D b) => a.X != b.X || a.Y != b.Y;
        public static implicit operator (double x, double y)(Vec2D a) => (x: a.X, y: a.Y);
        public static implicit operator Vec2D((double x, double y) a) => new Vec2D(a.x, a.y);
        public static double Manhattan(Vec2D a, Vec2D b)
        {
            return System.Math.Abs(a.X - b.X) + System.Math.Abs(a.Y - b.Y);
        }
        public static double Euclidean(Vec2D a, Vec2D b)
        {
            return System.Math.Sqrt(System.Math.Pow(a.X - b.X, 2) + System.Math.Pow(a.Y - b.Y, 2));
        }
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}