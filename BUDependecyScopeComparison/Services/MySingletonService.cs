namespace BUDependecyScopeComparison.Services;

public class MySingletonService : IMySingletonService
{
    public TimeSpan DeltaCreationTime { get; }
    public int InstanceNumber { get; }

    private static volatile int _previousInstanceNumber;

    public MySingletonService()
    {
        DeltaCreationTime = DateTime.UtcNow - AppLifetime.StartTimeUtc;
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
