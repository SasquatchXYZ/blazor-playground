namespace BUOwningMultipleDependenciesWrong.Services;

public interface IOwnedDependency
{
    public int InstanceNumber { get; }
}

public class OwnedDependency : IOwnedDependency
{
    private static volatile int _previousInstanceNumber;
    public int InstanceNumber { get; }

    public OwnedDependency()
    {
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
