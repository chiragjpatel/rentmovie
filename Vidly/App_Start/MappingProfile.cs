using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<CustomerDtos, Customer>();
            Mapper.CreateMap<Movie, MovieDtos>();
            Mapper.CreateMap<MovieDtos, Movie>();
        }
    }
}