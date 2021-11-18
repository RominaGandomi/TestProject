﻿using Albelli.Business.Models;
using Albelli.Business.Models.Dto;
using Albelli.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.Business.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<OrderModel, Order>();
            CreateMap<OrderItemModel, OrderItem>();
            CreateMap<ProductTypeModel, ProductType>();
            CreateMap<Order, OrderModel>();
            CreateMap<OrderItem, OrderItemModel>();
            CreateMap<ProductType, ProductTypeModel>();

            CreateMap<OrderModel, GetOrderOutput>()
                 .ForMember(dest => dest.OrderId, opt =>
                 {
                     opt.MapFrom(src => src.Id);
                 })
                 .ForMember(dest => dest.MinimumBinWidth, opt =>
                 {
                     opt.MapFrom(src => src.MinimumBinWidth);
                 })
                  .ForMember(dest => dest.Items, opt =>
                  {
                      opt.MapFrom(src => src.Items);
                  })
                 ;

            CreateMap<OrderItemModel, OrderDetail>()
                 .ForMember(dest => dest.Quantity, opt =>
                 {
                     opt.MapFrom(src => src.Quantity);
                 })
                 .ForMember(dest => dest.Product, opt =>
                 {
                     opt.MapFrom(src => src.ProductType.Name);
                 })
                 ;
        }
    
    }
}
