using AutoMapper;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using ElectricStoreProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CommonCategoryResponse>().ReverseMap();
            CreateMap<Product, CommonProductResponse>().ReverseMap();
            CreateMap<Order, CreateOrderRequest>().ForMember(des => des.CommonOrderDetailRequest,
                opt => opt.MapFrom(src => src.OrderDetails)).ReverseMap();
        }

    }
}
