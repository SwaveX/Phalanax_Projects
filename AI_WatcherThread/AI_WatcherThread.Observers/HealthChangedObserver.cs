using Core_Health.Domain;
using AI_WatcherThread.Runtime;

namespace AI_WatcherThread.Observers;
    
public class HealthChangedObserver
{
    private readonly AIWatcherRuntime _runtime;

    public HealthChangedObserver(AIWatcherRuntime runtime)
    {
        _runtime = runtime;
    }

    public void Subscribe(Health health)
    {
        // _, _ are the eventArgs - yes: (sender, e)
        health.OnHealthChanged += (_, e) =>
        {
            _runtime.EnqueueAction( () =>
            {
                Console.WriteLine($"Health changed: {e.CurrentHP} / {e.MaximumHP}");
            });
        };
    }
}
