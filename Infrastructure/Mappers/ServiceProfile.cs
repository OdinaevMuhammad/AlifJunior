using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Order,OrderDto>().ReverseMap();
        }
    }
}