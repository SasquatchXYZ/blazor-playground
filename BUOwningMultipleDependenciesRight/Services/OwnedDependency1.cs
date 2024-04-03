using System.Diagnostics;

namespace BUOwningMultipleDependenciesRight.Services;

public interface IOwnedDependency1
{
    public int InstanceNumber { get; }
}

public class OwnedDependency1 : IOwnedDependency1, IDisposable
{
    private static volatile int _previousInstanceNumber;

    public int InstanceNumber { get; }

    public OwnedDependency1()
    {
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
        Debug.WriteLine($"Created {GetType().Name} instance {InstanceNumber}");
    }

    public void Dispose()
    {
        Debug.WriteLine($"Disposing {GetType().Name} instance {InstanceNumber}");
        GC.SuppressFinalize(this);
    }
}
