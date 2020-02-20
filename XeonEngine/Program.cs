using XeonCore.Math.Vector;
using System;

namespace XeonEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Vec2D pos = (1, 1);
            Vec2D npos = pos * (2, 5);
            Console.WriteLine($"Pos: {pos}\nNPos: {npos}\nEuclidean: {Vec2D.Euclidean(pos, npos)}\nManhattan: {Vec2D.Manhattan(pos, npos)}");
        }
    }
}
