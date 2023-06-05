using AutoMapper;
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

        }
    }
}
