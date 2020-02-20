/*
    Vector math library
*/
using System;
using LiteDB;

namespace XeonCore.Math.Vector
{
    /// <summary>A structure defining a two-dimensional Vector.</summary>
    public struct Vec2D
    {
        /// <summary>The X coordinate of this vector.</summary>
        public double X;
        /// <summary>The Y coordinate of this vector.</summary>
        public double Y;
        /// <summary>A TypeRegister for the LiteDB BsonMapper.</summary>
        public static TypeRegister<Vec2D> Mapped = new TypeRegister<Vec2D>
        {
            Serialize = (x) => x,
            Deserialize = (x) => (Vec2D)x
        };
        /// <summary>Add two Vec2D values.</summary>
        public static Vec2D operator +(Vec2D a, Vec2D b) => new Vec2D { X = a.X + b.X, Y = a.Y + b.Y };
        /// <summary>Subtract two Vec2D values.</summary>
        public static Vec2D operator -(Vec2D a, Vec2D b) => new Vec2D { X = a.X - b.X, Y = a.Y - b.Y };
        /// <summary>Multiply two Vec2D values.</summary>
        public static Vec2D operator *(Vec2D a, Vec2D b) => new Vec2D { X = a.X * b.X, Y = a.Y * b.Y };
        /// <summary>Multiply a Vec2D by a double.</summary>
        public static Vec2D operator *(Vec2D a, double b) => new Vec2D { X = a.X * b, Y = a.Y * b };
        /// <summary>Multiply a Vec2D by a double.</summary>
        public static Vec2D operator *(double a, Vec2D b) => new Vec2D { X = a * b.X, Y = a * b.Y };
        /// <summary>Divide two Vec2D values.</summary>
        public static Vec2D operator /(Vec2D a, Vec2D b) => new Vec2D { X = a.X / b.X, Y = a.Y / b.Y };
        /// <summary>Divide a Vec2D by a double.</summary>
        public static Vec2D operator /(Vec2D a, double b) => new Vec2D { X = a.X / b, Y = a.Y / b };
        /// <summary>Divide a Vec2D by a double.</summary>
        public static Vec2D operator /(double a, Vec2D b) => new Vec2D { X = a / b.X, Y = a / b.Y };
        /// <summary>Implicitly cast a Vec2D to a ValueTuple.</summary>
        public static implicit operator ValueTuple<double, double>(Vec2D a) => (a.X, a.Y);
        /// <summary>Implicitly cast a ValueTuple to a Vec2D.</summary>
        public static implicit operator Vec2D(ValueTuple<double, double> a) => new Vec2D { X = a.Item1, Y = a.Item2 };
        /// <summary>Implicitly cast a Vec2D to a BsonValue[].</summary>
        public static implicit operator BsonValue[](Vec2D a) => new BsonValue[] { new BsonValue(a.X), new BsonValue(a.Y) };
        /// <summary>Implicitly cast a Vec2D to a BsonArray.</summary>
        public static implicit operator BsonArray(Vec2D a) => new BsonArray(a);
        /// <summary>Explicitly cast a BsonValue to a Vec2D.</summary>
        public static explicit operator Vec2D(BsonValue a)
        {
            if (a.IsArray)
            {
                BsonArray b = a.AsArray;
                if (b.Count >= 2 && b[0].IsNumber && b[1].IsNumber)
                    return new Vec2D { X = b[0].AsDouble, Y = b[1].AsDouble };
            }
            throw new InvalidCastException();
        }
        /// <summary>Implicitly cast a Vec2D to a double[].</summary>
        public static implicit operator double[](Vec2D a) => new double[] { a.X, a.Y };
        /// <summary>Implicitly cast a double[] to a Vec2D.</summary>
        public static implicit operator Vec2D(double[] a) => new Vec2D { X = a[0], Y = a[1] };
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
    }
}