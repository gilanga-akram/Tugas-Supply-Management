using Microsoft.EntityFrameworkCore;
using SupplyManagement.Web.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SupplyManagementDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


var app = builder.Build();

LocationEndpointsConfig.AddEndpoints(app);

app.Run();