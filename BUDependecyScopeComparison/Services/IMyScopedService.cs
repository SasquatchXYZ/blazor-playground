namespace BUDependecyScopeComparison.Services;

public interface IMyScopedService
{
    public TimeSpan DeltaCreationTime { get; }
    public int InstanceNumber { get; }
}
