using XeonCore.Math.Vector;

namespace XeonCore.Game
{
    /// <summary>A physical entity in the game world.</summary>
    public interface IEntity
    {
        /// <summary>Entity's position in the current map.</summary>
        public Vec2D Position { get; set; }
    }
}