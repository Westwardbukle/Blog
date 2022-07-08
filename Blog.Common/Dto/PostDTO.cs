using System.ComponentModel.DataAnnotations;

namespace BlogCommon.Dto;

public class PostDto
{
    [Required]
    public string Heading { get; set; }
    
    [Required]
    public string Text { get; set; }
}