using XeonCore.Collections.Generic;

namespace XeonCore.Game
{
    /// <summary>An entity that can contain other entities.</summary>
    public interface IContainer : IEntity
    {
        /// <summary>A Mutex-backed List containing the entities inside of this container.</summary>
        public MutList<IEntity> Interior { get; }
    }
}