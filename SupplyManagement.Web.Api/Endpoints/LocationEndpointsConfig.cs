using UserModel.Web.Api.Models;

namespace SupplyManagement.Web.Api.Endpoints
{
    public class LocationEndpointsConfig
    {


        public static void AddEndpoints(WebApplication app)
        {
            app.MapGet("api/find/users", () =>
            {

                var supplyManagement = Enumerable.Range(1, 5).Select(index => new UserModels
                {
                    Username = "Gilang",
                    Password = "Test",
                })
                .ToArray();

                return Results.Ok(supplyManagement);
            });
        }
    }
}