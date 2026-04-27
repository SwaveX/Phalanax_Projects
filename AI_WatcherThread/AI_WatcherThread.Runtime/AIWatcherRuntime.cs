using System.Collections.Concurrent;
using System.Threading;

namespace AI_WatcherThread.Runtime;

public class AIWatcherRuntime
{
    private readonly ConcurrentQueue<Action> _queue = new();
    private bool _isRunning = false;

    public void EnqueueAction(Action action)
    {
        _queue.Enqueue(action);
    }

    public void Start()
    {
        _isRunning = true;
        
        new Thread(
        () => 
        {
            while (_isRunning)
            {
                while (_queue.TryDequeue(out var action))
                {
                    action();
                }

                Thread.Sleep(10);
            }           
        }).Start();
    }


}



