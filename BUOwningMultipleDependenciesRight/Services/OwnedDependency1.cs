namespace BUOwningMultipleDependenciesRight.Services;

public interface IOwnedDependency1
{
    public int InstanceNumber { get; }
}

public class OwnedDependency1 : IOwnedDependency1
{
    private static volatile int _previousInstanceNumber;

    public int InstanceNumber { get; }

    public OwnedDependency1()
    {
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
