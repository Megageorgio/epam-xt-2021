namespace Task2_2
{
    public abstract class Effect : GameObject, IEffect
    {
        protected virtual int Lifetime { get; private set; } = 2;

        public void Update()
        {
            Lifetime--;
            if (Lifetime <= 0)
            {
                Board.Remove(this);
            }
        }
    }
}