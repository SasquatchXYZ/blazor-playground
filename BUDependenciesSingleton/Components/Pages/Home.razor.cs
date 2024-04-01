using System.ComponentModel.DataAnnotations;

namespace BUDependenciesSingleton.Components.Pages;

public partial class Home
{
    [Required(ErrorMessage = "Enter name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Enter a message")]
    public string Text { get; set; }
}
