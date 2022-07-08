using Blog.Database.Models;
using BlogCommon.Dto;

namespace BlogCore.Abstract;

public interface IPostService
{
    Task CreatePost(PostDto postDto);

    Task<PostModel> GetPost(Guid postId);
}