
using AutoMapper;
using Clothing_Api.Data.Entities;
using Clothing_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothing_Api.Data
{
    public class ClothingProfile : Profile
    {
        public ClothingProfile()
        {
            this.CreateMap<ProductEntity, Product>()
                .ReverseMap();
        }
    }
}
