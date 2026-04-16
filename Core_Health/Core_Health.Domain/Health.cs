namespace Core_Health.Domain;

public class Health
{
    public event EventHandler<HealthChangedEventArgs> OnHealthChanged;
    public event EventHandler? OnDeath;
    public event EventHandler? OnResurrection;

    private const int _defaultMaxHp = 100;

    public int CurrentHP { get; private set; }
    public int MaximumHP { get; private set; }
    public bool IsDead { get; private set; }

    public Health(int maxHP = _defaultMaxHp)
    {
        MaximumHP = maxHP;
        CurrentHP = MaximumHP;
        IsDead = false;
    }

    public void DealDamage(int receivedDmg)
	{
        if (IsDead)
        {
            return;
        }

        CurrentHP = Math.Max(0, CurrentHP - receivedDmg);

        OnHealthChanged?.Invoke(this, new HealthChangedEventArgs(CurrentHP, MaximumHP)); // 🔥 THIS is the event trigger
   
        if (CurrentHP == 0 && !IsDead)
        {
            IsDead = true;

            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RestoreHealth(int receivedHealth)
    {
        if (IsDead)
        {
            return;
        }

        CurrentHP = Math.Min(MaximumHP, CurrentHP + receivedHealth);

        /// Without EventHandler, using pure Action
        /// OnHealthChanged?.Invoke(CurrentHP, MaximumHP); 
        OnHealthChanged?.Invoke(this, new HealthChangedEventArgs(CurrentHP, MaximumHP));
    }

    public void Resurrection(int hp = _defaultMaxHp)
    {
        if (!IsDead)
        {
            return;
        }

        CurrentHP = Math.Max( 1, Math.Min(hp, MaximumHP) );
        IsDead = false;

        OnHealthChanged?.Invoke(this, new HealthChangedEventArgs(CurrentHP, MaximumHP));
        OnResurrection?.Invoke(this, EventArgs.Empty);
    }
}
