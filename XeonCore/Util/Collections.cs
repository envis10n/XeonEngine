using System.Collections.Generic;
using XeonCore.Locks.Generic;

namespace XeonCore.Collections.Generic
{
    /// <summary>A List wrapped by an AutoMutex.</summary>
    public class MutList<T> : AutoMutex<List<T>>
    {
        /// <summary>Create a MutList with a fresh List.</summary>
        public MutList() : base(new List<T>()) { }
        /// <summary>Create a MutList with an existing List.</summary>
        public MutList(List<T> list) : base(new List<T>(list.ToArray())) { }
    }
}