using Core_Health.Domain;

namespace Core_Health.Abstractions;

public interface IHealthView
{
    void Update(object sender, HealthChangedEventArgs e);
}
