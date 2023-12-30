using SupplyManagement.Web.Models;

namespace ISupplyForecastService.Web.Services.Interfaces
{
    public interface ISupplyForecastServices
    {
        Task<IEnumerable<SupplyManagements>> Find();
    }
}