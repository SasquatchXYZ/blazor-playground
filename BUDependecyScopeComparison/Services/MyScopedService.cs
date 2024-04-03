namespace BUDependecyScopeComparison.Services;

public class MyScopedService : IMyScopedService
{
    public TimeSpan DeltaCreationTime { get; }
    public int InstanceNumber { get; }

    private static volatile int _previousInstanceNumber;

    public MyScopedService()
    {
        DeltaCreationTime = DateTime.UtcNow - AppLifetime.StartTimeUtc;
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
