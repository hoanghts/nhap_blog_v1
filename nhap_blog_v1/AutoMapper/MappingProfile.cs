
using AutoMapper;
using nhap_blog_v1.Models;
using nhap_blog_v1.Dto;

namespace nhap_blog_v1.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentFullDto>();
            CreateMap<CommentFullDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostFullDto>();
            CreateMap<PostFullDto, Post>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
    }
}
