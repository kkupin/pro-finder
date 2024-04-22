using AutoMapper;
using ProFinder.ApplicationCore.DTO;
using ProFinder.Infrastructure.Entities;

namespace ProFinder.ApplicationCore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<AddCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();

            CreateMap<Post, PostDTO>();
            CreateMap<AddPostDTO, Post>();
            CreateMap<UpdatePostDTO, Post>();

            CreateMap<Review, ReviewDTO>();
            CreateMap<AddReviewDTO, Review>();
            CreateMap<UpdateReviewDTO, Review>();

            CreateMap<Comment, CommentDTO>();
            CreateMap<AddCommentDTO, Comment>();
            CreateMap<UpdateCommentDTO, Comment>();
        }
    }
}