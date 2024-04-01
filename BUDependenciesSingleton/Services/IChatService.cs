namespace BUDependenciesSingleton.Services;

public interface IChatService
{
    bool SendMessage(string username, string message);
    List<string>? ChatWindowText { get; }
    event EventHandler TextAdded;
}
