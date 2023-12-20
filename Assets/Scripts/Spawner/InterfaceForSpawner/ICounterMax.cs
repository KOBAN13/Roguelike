namespace Enemy.Interface
{
    public interface ICounterMax
    {
        int MaximumNumberOfBoarUnits { get; }
        int MaximumNumberOfWolfUnits { get; }
        int MaximumNumberOfHumanUnits { get; }
        int MaximumNumberOfOrkUnits { get; }
    }
}