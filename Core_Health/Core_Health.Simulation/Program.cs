using Core_Health.Domain;
using Core_Health.Abstractions;
using Core_Health.Presentation.Console;

namespace Core_Health.Simulation;

public class Program
{
    static void Main()
    {
        ConsoleStyle.WriteLine("== En tya phya, Phal y' Nax ==\n", ConsoleColor.DarkYellow);

        Thread.Sleep(1000);
    
        ConsoleStyle.WriteLine("Engaging Test:\n\t Health System\n", ConsoleColor.Cyan);


        Health health = new Health(1000);
        IHealthView viewHealthBar = new HealthBar();

        health.OnHealthChanged += viewHealthBar.Update;


        ConsoleStyle.WriteLine("Damaging...", ConsoleColor.Red);
        health.DealDamage(50);

        ConsoleStyle.WriteLine("Healing...", ConsoleColor.Green);
        health.RestoreHealth(40);

        ConsoleStyle.WriteLine("Kill", ConsoleColor.DarkMagenta);
        health.DealDamage(health.CurrentHP);

        ConsoleStyle.WriteLine("Rise my child", ConsoleColor.Cyan);
        health.Resurrection();


        health.OnHealthChanged -= viewHealthBar.Update;
    }
}
