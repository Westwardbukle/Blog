using System.Linq.Expressions;
using Blog.Database.Models;

namespace Blog.Database.Abstraction;

public interface IPostRepository
{
    Task CreatePost(PostModel postModel);

    Task<PostModel> GetPost(Expression<Func<PostModel, bool>> predicate);
}