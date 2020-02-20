using LiteDB;
using System;
using XeonCore.Math.Vector;

namespace XeonCore
{
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
            BsonMapper.Global.RegisterType<Vec2D>(
                Vec2D.Mapped.Serialize,
                Vec2D.Mapped.Deserialize
            );
        }
    }
}