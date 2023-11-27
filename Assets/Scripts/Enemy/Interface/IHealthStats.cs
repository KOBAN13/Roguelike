namespace Enemy.Interface
{
    public interface IHealthStats
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
        void SetDamage(float value);
        void AddHealth(float value);
    }
}