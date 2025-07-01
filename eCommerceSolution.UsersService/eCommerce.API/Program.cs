using eCommerce.Core;
using eCommerce.Infrastructure;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);
// Add Infrastructure Service
builder.Services.AddInfrastructure();
// Add Core Service
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions
    (options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegisterRequestMappingProfile).Assembly);


//Build the Web application
var app = builder.Build();
app.UseExceptionHandlingMiddleware();

//  Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//controller routes
app.MapControllers();
app.Run();
