using System.Diagnostics;

namespace BUOwningMultipleDependenciesRight.Services;

public interface IOwnedDependency2
{
    public int InstanceNumber { get; }
}

public class OwnedDependency2 : IOwnedDependency2, IDisposable
{
    private static volatile int _previousInstanceNumber;

    public int InstanceNumber { get; }

    public OwnedDependency2()
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
