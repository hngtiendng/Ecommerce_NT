using SharedVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Services.Interfaces
{
    public interface IProductApiClient
    {
        Task<ProductVm> GetProductById(int id);
        Task<IList<ProductVm>> GetProductByCategory(int idCategory);
        Task<IList<ProductVm>> GetAllProduct();
    }
}
