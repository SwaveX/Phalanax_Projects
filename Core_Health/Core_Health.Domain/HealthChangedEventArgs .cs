using System;
using System.Collections.Generic;
using System.Text;

namespace Core_Health.Domain;

public class HealthChangedEventArgs : EventArgs
{
    public int CurrentHP { get; }
    public int MaximumHP { get; }

    public HealthChangedEventArgs(int current, int max)
    {
        CurrentHP = current;
        MaximumHP = max;
    }
}
