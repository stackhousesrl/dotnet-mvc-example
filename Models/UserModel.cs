using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}