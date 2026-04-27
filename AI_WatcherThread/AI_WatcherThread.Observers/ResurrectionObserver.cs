using Core_Health.Domain;
using AI_WatcherThread.Runtime;

namespace AI_WatcherThread.Observers;

public class ResurrectionObserver
{
    private readonly AIWatcherRuntime _runtime;

    public ResurrectionObserver(AIWatcherRuntime runtime)
    {
        _runtime = runtime;
    }

    public void Subscribe(Health health)
    {
        health.OnResurrection += (_, _) =>
        {
            _runtime.EnqueAction( () =>
            {
                Console.WriteLine("Entity has resurrected!");
            });
        };
    }
}