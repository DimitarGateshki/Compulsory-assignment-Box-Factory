using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace infrastructure.DataModels;

public class Box
{
    [Required, NotNull]
    public int Id { get; set; }
    
    [Required, MinLength(3), MaxLength(50)]
    public string Name { get; set; }
    public DateTime DateOfCreation { get; set; }
    [Required, MinLength(3), MaxLength(50)]
    public string Category { get; set; }
}