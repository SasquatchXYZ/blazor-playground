namespace BUDependenciesTransient.Services;

public sealed class MyTransientService : IMyTransientService
{
    public int InstanceNumber { get; }

    private static volatile int PreviousInstanceNumber;

    public MyTransientService()
    {
        InstanceNumber = Interlocked.Increment(ref PreviousInstanceNumber);
    }
}
