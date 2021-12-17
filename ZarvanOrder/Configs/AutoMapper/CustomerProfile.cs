using AutoMapper;

namespace ZarvanOrder.Configs.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Model.Entites.Customer, Model.Dtos.Responses.Customers.CustomerResponse>().ReverseMap();
            CreateMap<Model.Entites.Customer, Model.Dtos.Requests.Customers.AddCustomerRequest>();
            CreateMap<Model.Entites.Customer, Model.Dtos.Requests.Customers.EditCustomerRequest>();
            CreateMap<Model.Entites.Customer, Model.Dtos.Requests.Customers.GetCustomerRequest>();
        }
    }
}
