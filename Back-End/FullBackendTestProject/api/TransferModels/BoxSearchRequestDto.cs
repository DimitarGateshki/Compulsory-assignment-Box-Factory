using System.ComponentModel.DataAnnotations;

namespace infrastructure.TranferModels;

public class BoxSearchRequestDto
{
    [MinLength(1)]
    public string? SearchTerm { get; set; }
    
    [Range(1, Int32.MaxValue)]
    public int PageSize { get; set; }
    
}