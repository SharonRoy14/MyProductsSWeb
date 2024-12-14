using AutoMapper;
using MyProductsS.Models;
namespace MyProductsS.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Productmap>();
        }
    }
}

 