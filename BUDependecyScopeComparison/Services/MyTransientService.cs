namespace BUDependecyScopeComparison.Services;

public class MyTransientService : IMyTransientService
{
    public TimeSpan DeltaCreationTime { get; }
    public int InstanceNumber { get; }

    private static volatile int _previousInstanceNumber;

    public MyTransientService()
    {
        DeltaCreationTime = DateTime.UtcNow - AppLifetime.StartTimeUtc;
        InstanceNumber = Interlocked.Increment(ref _previousInstanceNumber);
    }
}
