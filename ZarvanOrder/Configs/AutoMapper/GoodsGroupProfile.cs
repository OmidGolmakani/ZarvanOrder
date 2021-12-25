using AutoMapper;

namespace ZarvanOrder.Configs.AutoMapper
{
    public class GoodsGroupProfile : Profile
    {
        public GoodsGroupProfile()
        {
            CreateMap<Model.Entites.GoodsGroup, Model.Dtos.Responses.GoodsGroups.GoodsGroupResponse>()
           .ForMember(dest => dest.FatherCode, opt => opt.MapFrom(src => src.FatherGoodsGroup.Code))
            .ForMember(dest => dest.FatherId, opt => opt.MapFrom(src => src.FatherGoodsGroup.FatherId))
            .ForMember(dest => dest.FatherName, opt => opt.MapFrom(src => src.FatherGoodsGroup.Name));
            CreateMap<Model.Dtos.Responses.GoodsGroups.GoodsGroupResponse, Model.Entites.GoodsGroup>();
            CreateMap<Model.Entites.GoodsGroup, Model.Dtos.Requests.GoodsGroups.AddGoodsGroupRequest>().ReverseMap();
            CreateMap<Model.Entites.GoodsGroup, Model.Dtos.Requests.GoodsGroups.EditGoodsGroupRequest>().ReverseMap();
            CreateMap<Model.Entites.GoodsGroup, Model.Dtos.Requests.GoodsGroups.GetGoodsGroupRequest>().ReverseMap();
        }
    }
}
