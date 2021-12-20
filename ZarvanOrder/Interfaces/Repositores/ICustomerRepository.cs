using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface ICustomerRepository : IRepository<long, Model.Entites.Customer>, 
                                           IGetRepository<GetCustomerRequest, GetCustomersRequest, Customer>
    {

    }
}
