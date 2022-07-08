using Blog.Database.Models;
using BlogCommon.Dto;
using BlogCore.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("/api/v{version:apiVersion}/[controller]s")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    
    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePost(PostDto postDto)
    {
       await _postService.CreatePost(postDto);

        return Ok();
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPost(Guid postId)
    {
        var model = await _postService.GetPost(postId);

        return Ok(model);
    }
}