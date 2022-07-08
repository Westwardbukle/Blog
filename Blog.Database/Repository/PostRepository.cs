using System.Linq.Expressions;
using Blog.Database.Abstraction;
using Blog.Database.Models;

namespace Blog.Database.Repository;

public class PostRepository : BaseRepository<PostModel>, IPostRepository
{
    public PostRepository(AppDbContext appDbContext) : base(appDbContext) { }
    
    public async Task CreatePost(PostModel postModel) 
        => await CreateAsync(postModel);

    public async Task<PostModel> GetPost(Expression<Func<PostModel, bool>> predicate)
        => await GetOneAsync(predicate);
}