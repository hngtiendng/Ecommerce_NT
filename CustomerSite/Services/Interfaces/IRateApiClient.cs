using SharedVm;
using System.Threading.Tasks;

namespace CustomerSite.Services.Interfaces
{
    public interface IRateApiClient
    {
        Task<RateVm> CreateRate(RateVm rateVm);
        Task<RateVm> GetRateByProduct(int productId);
    }
}
