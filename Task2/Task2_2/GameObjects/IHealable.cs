namespace Task2_2
{
    public interface IHealable : IAttackable
    {
        void Heal(int points);
    }
}