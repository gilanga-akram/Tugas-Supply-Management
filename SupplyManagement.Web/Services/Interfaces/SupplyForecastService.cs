using SupplyManagement.Web.Models;
using SupplyManagement.Web.Helpers;
using ISupplyForecastService.Web.Services.Interfaces;

namespace SupplyForecastService.Web.Services
{
    public class SupplyForecastServices : ISupplyForecastServices
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/find/users";

        public SupplyForecastServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<SupplyManagements>> Find()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<SupplyManagements>>();
        }
    }
}