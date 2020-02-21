using XeonCore.Math.Vector;
using System;

namespace XeonCore.Game
{
    /// <summary>A physical entity in the game world.</summary>
    public interface IEntity
    {
        /// <summary>The entity's Guid.</summary>
        public Guid Id { get; }
        /// <summary>Entity's position in the current map.</summary>
        public Vec2D Position { get; }
    }
}