using System.ComponentModel.DataAnnotations.Schema;
using BlogCommon;

namespace Blog.Database.Models;

public class PostModel : BaseModel
{
    public string Heading { get; set; }
    
    public string Text { get; set; }
    
    [ForeignKey(nameof(Id))]
    public IEnumerable<CommentModel> Comments { get; set; }
}