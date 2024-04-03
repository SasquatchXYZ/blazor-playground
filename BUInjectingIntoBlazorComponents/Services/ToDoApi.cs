namespace BUInjectingIntoBlazorComponents.Services;

public interface IToDoApi
{
    Task<IEnumerable<ToDo>> GetToDosAsync();
}

public class ToDoApi : IToDoApi
{
    private readonly IEnumerable<ToDo> _data;

    public ToDoApi()
    {
        _data = new ToDo[]
        {
            new() { Id = 1, Title = "To Do 1", Completed = true },
            new() { Id = 2, Title = "To Do 2", Completed = false },
            new() { Id = 3, Title = "To Do 3", Completed = false }
        };
    }

    public Task<IEnumerable<ToDo>> GetToDosAsync() => Task.FromResult(_data);
}
