﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Models.Mapping
{
   public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //Skapa user
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>().ForMember(dest => dest.Password, opt => opt.Ignore());
            
            //Skapa userLogin
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginDto>().ForMember(dest => dest.Password, opt => opt.Ignore());

            //Hämta user
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>().ForMember(dest => dest.Password, opt => opt.Ignore());

            //Uppdatera user
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>().ForMember(dest => dest.Password, opt => opt.Ignore()).ForMember(dest => dest.Id, opt => opt.Ignore());


        }

    }
}
