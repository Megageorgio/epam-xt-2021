namespace Task2_2
{
    public interface IScoreHolder
    {
        int Score { get; }
        void AddScore(int score);
    }
}