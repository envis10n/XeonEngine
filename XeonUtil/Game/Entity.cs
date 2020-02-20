using XeonUtil.Math.Vector;

namespace XeonUtil.Game
{
    /// <summary>A physical entity in the game world.</summary>
    public interface IEntity
    {
        public Vec2D Position { get; set; }
        public void MoveTo(Vec2D pos);
        public void AddMovement(Vec2D move);
    }
}