namespace BUDependecyScopeComparison.Services;

public interface IMyTransientService
{
    public TimeSpan DeltaCreationTime { get; }
    public int InstanceNumber { get; }
}
