using Application.DTO_s;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
   public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, CreatePrdDto>().ReverseMap();
            CreateMap<Product, CreatePrdDto>().ReverseMap();
            CreateMap<Product, UpdatePrdDto>().ReverseMap();
            CreateMap<UpdatePrdDto, CreatePrdDto>().ReverseMap();
            CreateMap<UpdatePrdDto, ProductDto>().ReverseMap();

        }
    }
}
