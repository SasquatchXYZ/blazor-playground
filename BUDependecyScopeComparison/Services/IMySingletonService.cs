namespace BUDependecyScopeComparison.Services;

public interface IMySingletonService
{
    public TimeSpan DeltaCreationTime { get; }
    public int InstanceNumber { get; }
}
