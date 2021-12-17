using AutoMapper;

namespace ZarvanOrder.Configs.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Model.Entites.Customer, Model.Dtos.Responses.Customers.CustomerResponse>()
            .ForMember(dest => dest.CustomerTypeId, opt => opt.MapFrom(src => src.CustomerType))
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => $"{src.UserCustomer.Name} {src.UserCustomer.Family}"))
            .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => Helpers.Enumable.Find(typeof(Model.Enums.Customer),src.CustomerType)));
            CreateMap<Model.Dtos.Responses.Customers.CustomerResponse, Model.Entites.Customer>();
            CreateMap<Model.Entites.Customer, Model.Dtos.Requests.Customers.AddCustomerRequest>().ReverseMap();
            CreateMap<Model.Entites.Customer, Model.Dtos.Requests.Customers.EditCustomerRequest>().ReverseMap();
            CreateMap<Model.Entites.Customer, Model.Dtos.Requests.Customers.GetCustomerRequest>().ReverseMap();
        }
    }
}
