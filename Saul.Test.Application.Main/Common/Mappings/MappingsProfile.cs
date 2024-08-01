﻿using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Domain.Entities;
using Saul.Test.Domain.Events;

namespace Saul.Test.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Discount, DiscountCreatedEvent>().ReverseMap();
        }
    }
}
