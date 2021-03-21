namespace Task2_2
{
    public interface IPlayer : IGameObject, IAttackable, IHealable, IMovable,
        IBombHolder, IBatteryHolder, IScoreHolder
    {
        bool HandleInput(char input);
    }
}