using System.Collections.Concurrent;
using System;
using System.Threading;
using XeonCore.Locks;

namespace XeonCore.Events
{
    /// <summary>Alias for ConcurrentQueue.</summary>
    public class EventQueue : ConcurrentQueue<Action> { }
    /// <summary>An object that runs an internal thread for processing events from a queue.</summary>
    public class EventLoop
    {
        private AutoMutex mutex { get; set; }
        /// <summary>The calculated tick rate of the internal loop.</summary>
        public double TickRate { get; private set; }
        /// <summary>Internal thread used for the event loop.</summary>
        public Thread EventLoopThread { get; private set; }
        /// <summary>Whether or not the internal thread is alive.</summary>
        public bool IsAlive { get => EventLoopThread.IsAlive; }
        private EventQueue Events { get; set; }
        /// <summary>Construct a new EventLoop given a tick rate in hertz.</summary>
        /// <param name="tickHz">The tick rate in hertz.</param>
        public EventLoop(int tickHz)
        {
            TickRate = (1 / tickHz) * 1000;
            EventLoopThread = new Thread(StartEventLoop);
            Events = new EventQueue();
            mutex = new AutoMutex();
            EventLoopThread.Start();
        }
        /// <summary>Abort the internal thread to stop the event loop.</summary>
        public void Abort()
        {
            EventLoopThread.Abort();
        }
        /// <summary>Joins the internal thread.</summary>
        public void Join()
        {
            EventLoopThread.Join();
        }
        private void StartEventLoop()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(TickRate));
                if (Events.Count > 0)
                {
                    using (mutex.Lock())
                    {
                        while (Events.TryDequeue(out Action e))
                        {
                            e.Invoke();
                        }
                    }
                }
            }
        }
        /// <summary>Enqueue a new action to be processed in the event loop on the next available tick.</summary>
        /// <param name="action">The action to be invoked.</param>
        public void Enqueue(Action action)
        {
            using var loc = mutex.Lock();
            Events.Enqueue(action);
        }
    }
}