using AutoMapper;
using JobTaskCrud.Models;
using JobTaskCrud.responseDTOs;

namespace JobTaskCrud.Common.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        { 
            CreateMap<Product, GetAllProductResponse>().ReverseMap();
        }
    }
}
