namespace Blog.Database.Models;

public class CommentModel
{
    public string Text { get; set; }
    
    public PostModel PostModel { get; set; }
}