using AutoMapper;
using MuratYilmaz.Application.Features.Categories.CreateCategory;
using MuratYilmaz.Application.Features.Categories.UpdateCategory;
using MuratYilmaz.Application.Features.Products.CreateProduct;
using MuratYilmaz.Application.Features.Products.UpdateProduct;
using MuratYilmaz.Application.Features.Users.CreateUser;
using MuratYilmaz.Application.Features.Users.UpdateUser;
using MuratYilmaz.Domain.Entities;

namespace MuratYilmaz.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, AppUser>();
        CreateMap<UpdateUserCommand, AppUser>();
        
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
        
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}