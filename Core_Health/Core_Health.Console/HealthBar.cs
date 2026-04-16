using Core_Health.Domain;
using Core_Health.Abstractions;

namespace Core_Health.Presentation.Console;

public class HealthBar : IHealthView, IHealthViewSimple
{
    public void Update(object sender, HealthChangedEventArgs e)
    {
        System.Console.WriteLine($"HP: {e.CurrentHP}/{e.MaximumHP}\n");
    }

    public void Update(int currentHP, int maximumHP)
    {
        System.Console.WriteLine($"HP: {currentHP}/{maximumHP}\n");
    }
}
