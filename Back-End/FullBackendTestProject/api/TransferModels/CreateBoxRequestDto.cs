using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace infrastructure.TranferModels;

public class CreateBoxRequestDto
{
    [Required, MinLength(3), MaxLength(50)]
    public string BoxName { get; set; }
    
	
    public DateTime DateOfCreation { get; set; }
    
    [NotNull]
	[Required(ErrorMessage = "Must Be")]
	[RegularExpression("^(sold|not sold)$")]
    public string BoxCategory { get; set; }
    
}