using XeonCore.Game;
using XeonCore.Math.Vector;
using XeonCore.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace XeonEngine.Game
{
    public class Actor : IContainer
    {
        public Guid Id { get; }
        public MutList<IContainer> Interior { get; private set; }
        public Vec2D Position { get; private set; }
        public Actor()
        {
            Id = Guid.NewGuid();
            Position = new Vec2D { X = 0, Y = 0 };
            Interior = new MutList<IContainer>();
        }
        public Actor(Vec2D position)
        {
            Id = Guid.NewGuid();
            Position = position;
            Interior = new MutList<IContainer>();
        }
        public Actor(Guid _id, Vec2D position, MutList<IContainer> interior)
        {
            Id = _id;
            Position = position;
            Interior = interior;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}