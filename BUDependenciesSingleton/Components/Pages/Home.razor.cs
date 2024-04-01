using System.ComponentModel.DataAnnotations;
using BUDependenciesSingleton.Services;
using Microsoft.AspNetCore.Components;

namespace BUDependenciesSingleton.Components.Pages;

public partial class Home : IDisposable
{
    [Required(ErrorMessage = "Enter name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Enter a message")]
    public string Text { get; set; }

    [Inject] private IChatService ChatService { get; set; }

    private List<string>? ChatWindowText => ChatService.ChatWindowText;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ChatService.TextAdded += TextAdded;
    }

    private void SendMessage()
    {
        if (ChatService.SendMessage(Name, Text))
            Text = "";
    }

    private void TextAdded(object? sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        ChatService.TextAdded -= TextAdded;
        GC.SuppressFinalize(this);
    }
}
