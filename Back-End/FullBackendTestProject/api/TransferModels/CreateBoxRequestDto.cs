using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace infrastructure.TranferModels;

public class CreateBoxRequestDto
{
    [Required, MinLength(3), MaxLength(50)]
    public string BoxName { get; set; }
    
    [Required , NotNull]
    public DateTime DateOfCreation { get; set; }
    
    [Required, MinLength(3), MaxLength(50)]
    public string BoxCategory { get; set; }
    
}