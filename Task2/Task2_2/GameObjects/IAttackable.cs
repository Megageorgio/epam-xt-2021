namespace Task2_2
{
    public interface IAttackable
    {
        int MaxHealth { get; }
        int Health { get; }
        bool Damage(int points);
    }
}