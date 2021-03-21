namespace Task2_2
{
    public abstract class Bonus : GameObject, IBonus
    {
        protected abstract void ApplyEffect(IPlayer picker);

        public void Pick(IPlayer picker)
        {
            ApplyEffect(picker);
            Board.Remove(this);
        }
    }
}