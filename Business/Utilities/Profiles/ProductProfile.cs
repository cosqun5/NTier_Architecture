using AutoMapper;
using Entities;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Profiles
{
	public class ProductProfile:Profile
	{
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductUpdateDto,Product>();
        }

    }
}
