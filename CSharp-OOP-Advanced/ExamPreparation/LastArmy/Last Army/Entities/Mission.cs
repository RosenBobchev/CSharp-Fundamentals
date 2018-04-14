public abstract class Mission : IMission
{
    public Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }

    public double ScoreToComplete { get; }

    public abstract string Name { get; }

    public abstract double EnduranceRequired { get; }

    public abstract double WearLevelDecrement { get; }
}