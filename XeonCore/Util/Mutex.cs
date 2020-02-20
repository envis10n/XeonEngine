using System;
using System.Threading;

namespace XeonCore.Locks
{
    /// <summary>A disposable wrapper that automatically releases the parent mutex.</summary>
    public sealed class MutexLock : IDisposable
    {
        private Mutex mutRef;
        /// <summary>Takes a parent mutex, and generates a wrapper that releases it when disposed.</summary>
        /// <param name="mut">The parent mutex</param>
        public MutexLock(Mutex mut)
        {
            // Assign internal reference to external referenced mutex.
            mutRef = mut;
        }
        /// <summary>Disposes the wrapper, releasing the parent mutex.</summary>
        public void Dispose()
        {
            // Since mutex is a reference to our thread's locked one, we can release it on dispose.
            mutRef.ReleaseMutex();
        }
    }
    /// <summary>A mutex lock that automatically relaeses when the generated wrapper is disposed.</summary>
    public sealed class AutoMutex : IDisposable
    {
        private Mutex mut = new Mutex();
        /// <summary>Wait for a lock on the inner mutex, and return a disposable wrapper.</summary>
        /// <returns>A disposable wrapper that relases the inner mutex.</returns>
        public MutexLock Lock()
        {
            // Get a lock on the mutex from this thread.
            mut.WaitOne();
            // Return disposable wrapper.
            return new MutexLock(mut);
        }
        /// <summary>Dispose of the inner mutex.</summary>
        public void Dispose()
        {
            // Dispose of the inner mutex.
            mut.Dispose();
        }
    }
}

namespace XeonCore.Locks.Generic
{
    /// <summary>A disposable wrapper that automatically releases the parent mutex.</summary>
    public sealed class MutexLock<T> : IDisposable
    {
        /// <summary>The wrapped value.</summary>
        public readonly T Value;
        private Mutex mutRef;
        /// <summary>Takes a parent mutex, and generates a wrapper that releases it when disposed.</summary>
        /// <param name="mut">The parent mutex</param>
        /// <param name="value">The value wrapped by the parent.</param>
        public MutexLock(Mutex mut, T value)
        {
            // Assign internal reference to external referenced mutex.
            mutRef = mut;
            // Assign internal reference to external referenced value.
            Value = value;
        }
        /// <summary>Disposes the wrapper, releasing the parent mutex.</summary>
        public void Dispose()
        {
            // Since mutex is a reference to our thread's locked one, we can release it on dispose.
            mutRef.ReleaseMutex();
        }
    }
    /// <summary>A mutex lock that automatically relaeses when the generated wrapper is disposed.</summary>
    public class AutoMutex<T> : IDisposable
    {
        private T _value;
        private Mutex mut = new Mutex();
        /// <summary>Creates an AutoMutex that wraps a value.</summary>
        public AutoMutex(T value)
        {
            _value = value;
        }
        /// <summary>Wait for a lock on the inner mutex, and return a disposable wrapper.</summary>
        /// <returns>A disposable wrapper that relases the inner mutex.</returns>
        public MutexLock<T> Lock()
        {
            // Get a lock on the mutex from this thread.
            mut.WaitOne();
            // Return disposable wrapper.
            return new MutexLock<T>(mut, _value);
        }
        /// <summary>Dispose of the inner mutex.</summary>
        public void Dispose()
        {
            // Dispose of the inner mutex.
            mut.Dispose();
        }
    }
}