using AutoMapper;
using Blog.Database.Models;
using BlogCommon.Dto;

namespace BlogCore.ProFiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<PostDto, PostModel>();
    }
}