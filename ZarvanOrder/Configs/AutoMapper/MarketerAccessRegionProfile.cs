using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Configs.AutoMapper
{
    public class MarketerAccessRegionProfile : Profile
    {
        public MarketerAccessRegionProfile()
        {
            CreateMap<Model.Entites.MarketerAccessRegion, Model.Dtos.Responses.MarketerAccessRegions.MarketerAccessRegionResponse>();
            CreateMap<Model.Dtos.Responses.MarketerAccessRegions.MarketerAccessRegionResponse, Model.Entites.MarketerAccessRegion>();
            CreateMap<Model.Entites.MarketerAccessRegion, Model.Dtos.Requests.MarketerAccessRegions.AddMarketerAccessRegionRequest>().ReverseMap();
            CreateMap<Model.Entites.MarketerAccessRegion, Model.Dtos.Requests.MarketerAccessRegions.EditMarketerAccessRegionRequest>().ReverseMap();
            CreateMap<Model.Entites.MarketerAccessRegion, Model.Dtos.Requests.MarketerAccessRegions.GetMarketerAccessRegionRequest>().ReverseMap();
        }
    }
}
