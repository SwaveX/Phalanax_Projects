using Core_Health.Domain;
using AI_WatcherThread.Runtime;

namespace AI_WatcherThread.Observers;

public class DeathObserver
{
    private readonly AIWatcherRuntime _runtime;

    public DeathObserver(AIWatcherRuntime runtime)
    {
        _runtime = runtime;
    }

    public void Subsrcibe(Health health)
    {
        health.OnDeath += (_, _) =>
        {
            _runtime.EnqueueAction(() =>
            {
                Console.WriteLine("Entity has died!");
            });
        };
    }
}

