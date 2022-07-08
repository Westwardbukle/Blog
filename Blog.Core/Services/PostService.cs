using AutoMapper;
using Blog.Database.Abstraction;
using Blog.Database.Models;
using BlogCommon.Dto;
using BlogCommon.Exceptions;
using BlogCore.Abstract;

namespace BlogCore.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task CreatePost(PostDto postDto)
    {
        await _postRepository.CreatePost(_mapper.Map<PostDto, PostModel>(postDto));
    }

    public async Task<PostModel> GetPost(Guid postId)
    {
        var model = await _postRepository.GetPost(p => p.Id == postId);

        if (model is null)
        {
            throw new PostNotFoundException();
        }

        return model;
    } 
}