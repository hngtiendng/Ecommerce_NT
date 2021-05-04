using SharedVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Services.Interfaces
{
    public interface IOrderApiClient
    {
        Task<IList<OrderVm>> GetOrderByUser(string userId);
        Task<OrderVm> CreateOrder(string userId, List<OrderDetailVm> orderDetailVm1);
        Task<OrderVm> DeleteOrder(int id);
        Task<OrderVm> GetOrderDetail(int Id);
    }
}
