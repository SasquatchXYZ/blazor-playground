using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BUForms;

public class Person
{
    [Required] public string Name { get; set; }

    [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
    public int Age { get; set; }

    public Color FavoriteColor { get; set; }
}
