namespace BUOwningMultipleDependenciesWrong.Services;

public interface IInjectedDependency
{
    public int InstanceNumber { get; }
}

public class InjectedDependency : IInjectedDependency
{
    private static volatile int _previousInstanceNumber;
    public int InstanceNumber { get; }

    public InjectedDependency()
    {
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
