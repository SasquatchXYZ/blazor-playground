namespace BUOwningMultipleDependenciesRight.Services;

public interface IOwnedDependency2
{
    public int InstanceNumber { get; }
}

public class OwnedDependency2 : IOwnedDependency2
{
    private static volatile int _previousInstanceNumber;

    public int InstanceNumber { get; }

    public OwnedDependency2()
    {
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
