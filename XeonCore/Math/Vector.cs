/*
    Vector math library
*/
using System;

namespace XeonCore.Math.Vector
{
    /// <summary>Represents a 2-dimensional vector.</summary>
    public class Vec2D : Tuple<double, double>
    {
        /// <summary>X value of the 2D vector.</summary>
        public double X { get => Item1; }
        /// <summary>Y value of the 2D vector.</summary>
        public double Y { get => Item2; }
        /// <summary>Create a new Vec2D from 2 double values.</summary>
        public Vec2D(double x, double y) : base(x, y) { }
        /// <summary>Create a new Vec2D from a Tuple.</summary>
        public Vec2D((double x, double y) tuple) : base(tuple.x, tuple.y) { }
        /// <summary>Add two Vec2D values.</summary>
        public static Vec2D operator +(Vec2D a, Vec2D b) => new Vec2D(a.X + b.X, a.Y + b.Y);
        /// <summary>Subtract two Vec2D values.</summary>
        public static Vec2D operator -(Vec2D a, Vec2D b) => new Vec2D(a.X - b.X, a.Y - b.Y);
        /// <summary>Multiply two Vec2D values.</summary>
        public static Vec2D operator *(Vec2D a, Vec2D b) => new Vec2D(a.X * b.X, a.Y * b.Y);
        /// <summary>Multiply a Vec2D by a double.</summary>
        public static Vec2D operator *(Vec2D a, double b) => new Vec2D(a.X * b, a.Y * b);
        /// <summary>Multiply a Vec2D by a double.</summary>
        public static Vec2D operator *(double a, Vec2D b) => new Vec2D(a * b.X, a * b.Y);
        /// <summary>Divide two Vec2D values.</summary>
        public static Vec2D operator /(Vec2D a, Vec2D b) => new Vec2D(a.X / b.X, a.Y / b.Y);
        /// <summary>Divide a Vec2D by a double.</summary>
        public static Vec2D operator /(Vec2D a, double b) => new Vec2D(a.X / b, a.Y / b);
        /// <summary>Divide a Vec2D by a double.</summary>
        public static Vec2D operator /(double a, Vec2D b) => new Vec2D(a / b.X, a / b.Y);
        /// <summary>Compare Vec2D values.</summary>
        public static bool operator ==(Vec2D a, Vec2D b) => a.X == b.X && a.Y == b.Y;
        /// <summary>Compare Vec2D values.</summary>
        public static bool operator !=(Vec2D a, Vec2D b) => a.X != b.X || a.Y != b.Y;
        /// <summary>Implicitly cast a Vec2D to a named tuple.</summary>
        public static implicit operator (double x, double y)(Vec2D a) => (x: a.X, y: a.Y);
        /// <summary>Implicitly cast a named tuple to Vec2D.</summary>
        public static implicit operator Vec2D((double x, double y) a) => new Vec2D(a.x, a.y);
        /// <summary>Gets the Manhattan Distance between Vec2D values.</summary>
        public static double Manhattan(Vec2D a, Vec2D b)
        {
            return System.Math.Abs(a.X - b.X) + System.Math.Abs(a.Y - b.Y);
        }
        /// <summary>Gets the Euclidean Distance between Vec2D values.</summary>
        public static double Euclidean(Vec2D a, Vec2D b)
        {
            return System.Math.Sqrt(System.Math.Pow(a.X - b.X, 2) + System.Math.Pow(a.Y - b.Y, 2));
        }
        /// <summary>Returns the Vec2D as a human-readable string.</summary>
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
        /// <summary>Override Equals</summary>
#nullable enable
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
#nullable disable
        /// <summary>Override GetHashCode</summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}