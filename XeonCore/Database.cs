using LiteDB;
using System;

namespace XeonCore
{
    using Math.Vector;
    public struct TypeRegister<T>
    {
        public Func<T, BsonValue> Serialize;
        public Func<BsonValue, T> Deserialize;
    }
    public class Database
    {
        public readonly LiteDatabase LDB;
        public Database(string connectionString)
        {
            LDB = new LiteDatabase(connectionString);
            // Setup the global BsonMapper with required types.
            SetupMapper();
        }
        private void SetupMapper()
        {
            // Register Vec2D in the BsonMapper
            BsonMapper.Global.RegisterType<Math.Vector.Vec2D>(
                serialize: (x) => new BsonArray(new BsonValue[] { new BsonValue(x.X), new BsonValue(x.Y) }),
                deserialize: (x) =>
                {
                    if (x.IsArray)
                    {
                        BsonArray b = x.AsArray;
                        if (b.Count >= 2 && b[0].IsNumber && b[1].IsNumber)
                        {
                            return new Vec2D { X = b[0].AsDouble, Y = b[1].AsDouble };
                        }
                    }
                    throw new InvalidCastException();
                }
            );
        }
    }
}