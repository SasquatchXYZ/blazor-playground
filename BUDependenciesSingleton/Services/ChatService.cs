namespace BUDependenciesSingleton.Services;

public class ChatService : IChatService
{
    public event EventHandler? TextAdded;
    public List<string>? ChatWindowText { get; private set; }

    private readonly object SyncRoot = new();
    private List<string> ChatHistory = [];

    public bool SendMessage(string username, string message)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(message))
            return false;

        var line = $"<{username}> {message}";

        lock (SyncRoot)
        {
            ChatHistory.Add(line);
            while (ChatHistory.Count() > 50)
                ChatHistory.RemoveAt(0);

            ChatWindowText = ChatHistory.Take(50).ToList();
        }

        TextAdded?.Invoke(this, EventArgs.Empty);
        return true;
    }
}
