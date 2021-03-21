namespace Task2_2
{
    public interface IEnemy : IGameObject, IAttackable, IMovable
    {
        double Speed { get; }
        int Power { get; }
        int Score { get; }
        void Think();
    }
}