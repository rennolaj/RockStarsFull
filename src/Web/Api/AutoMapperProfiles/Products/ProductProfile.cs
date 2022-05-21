using AutoMapper;
using RockStars.Api.Controllers.v1.Products.Requests;
using RockStars.Application.Products.Command.AddProduct;

namespace RockStars.Api.AutoMapperProfiles.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductRequest, AddProductCommand>();
        }
    }
}
