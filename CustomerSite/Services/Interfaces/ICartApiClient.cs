using SharedVm;
using System.Threading.Tasks;

namespace CustomerSite.Services.Interfaces
{
    public interface ICartApiClient
    {
        Task<CartVm> CreateCart(CartVm cartVm);
        Task<CartVm> GetCartByUser(string userId);
        Task<CartVm> AddCartItem(string userId, int productId, int quantity);
        Task<CartVm> RemoveItem(string userId, int productId);
        Task<CartVm> ClearCart(string userId);
    }
}
