namespace BlogCommon.Exceptions;

public class PostNotFoundException : NotFoundException
{
    public PostNotFoundException() : base("Post not found") {}
}