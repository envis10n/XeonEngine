using LiteDB;
using System.IO;
using XeonCore.Collections.Generic;
using System.Collections.Generic;
using System;
using XeonCore.Game;
using XeonCore.Math.Vector;

namespace XeonEngine
{
    using Game;
    public static class Storage
    {
        public static LiteDatabase Database = new LiteDatabase(Path.Join(Program.AppDir, "database.db"));
        public static void Init()
        {
            BsonMapper mapper = Database.Mapper;

            // Vec2D
            mapper.RegisterType<Vec2D>(
                serialize: (x) => new BsonArray(new BsonValue[] { new BsonValue(x.X), new BsonValue(x.Y) }),
                deserialize: (x) =>
                {
                    var a = x.AsArray;
                    return new Vec2D { X = a[0].AsDouble, Y = a[1].AsDouble };
                }
            );

            mapper.RegisterType<IContainer>(
                serialize: (x) =>
                {
                    Type t = x.GetType();
                    BsonDocument d = mapper.Serialize(t, x).AsDocument;
                    d.Add("_type", t.AssemblyQualifiedName);
                    return d;
                },
                deserialize: (x) =>
                {
                    BsonDocument d = x.AsDocument;
                    Type t = Type.GetType(d["_type"]);
                    d.Remove("_type");
                    dynamic val = mapper.Deserialize(t, d);
                    return val;
                }
            );

            // MutList
            mapper.RegisterType<MutList<IContainer>>(
                serialize: (x) =>
                {
                    using (var list = x.Lock())
                    {
                        BsonArray a = new BsonArray();
                        foreach (IContainer e in list.Value)
                        {
                            a.Add(mapper.Serialize(e));
                        }
                        return a;
                    }
                },
                deserialize: (x) =>
                {
                    List<IContainer> l = new List<IContainer>();
                    BsonArray a = x.AsArray;
                    foreach (BsonValue v in a)
                    {
                        l.Add(mapper.Deserialize<IContainer>(v));
                    }
                    return new MutList<IContainer>(l);
                }
            );
        }
    }
}