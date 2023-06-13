using AutoMapper;
using CleanArchitecture.Core.Behaviours.Resolvers;
using CleanArchitecture.Core.DTOs.Post;
using CleanArchitecture.Core.DTOs.User;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Posts.Commands;
using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Features.Spaces.Commands;
using CleanArchitecture.Core.Features.User.Commands.CreateUser;

namespace CleanArchitecture.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
                      //from             //to
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDTO>();
            CreateMap<CreatePostViewModel, Post>();
            CreateMap<CreateSpaceCommand, Space>();
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.LikeCount, o => o.MapFrom<PostViewModelResolver>());

            /*var configuration = new MapperConfiguration(cfg =>
   cfg.CreateMap<Source, Destination>()
     .ForMember(dest => dest.Total, opt => opt.MapFrom<CustomResolver>()));

             = new MapperConfiguration(cfg => cfg.
            
            
            CreateMap<Source, Destination>().ForMember(dest => dest.Total,
		opt => opt.MapFrom(new CustomResolver())
	)
            
            
            
            
            
            );
            */


        }
    }
}
