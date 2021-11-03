﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Configs.AutoMapper
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Model.Dtos.Responses.Users.UserResponse, Model.Entites.User>().ReverseMap();
            CreateMap<Model.Dtos.Requests.Users.AddUserRequest, Model.Entites.User>().ReverseMap();
            CreateMap<Model.Dtos.Requests.Users.EditUserRequest, Model.Entites.User>().ReverseMap();
            CreateMap<Model.Dtos.Requests.Users.DeleteUserRequest, Model.Entites.User>().ReverseMap(); 
        }
    }
}
