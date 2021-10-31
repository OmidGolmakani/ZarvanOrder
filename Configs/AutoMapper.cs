using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Configs
{
    internal class AutoMapper : Profile
    {
        internal AutoMapper()
        {
            CreateMap<Model.Dtos.Responses.Users.User, Model.Entites.User>().ReverseMap();
        }
    }
}
