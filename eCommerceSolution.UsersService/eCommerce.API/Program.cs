using eCommerce.Core;
using eCommerce.Infrastructure;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validators;
using FluentValidation;
using eCommerce.API.Filters;
using eCommerce.Core.DTO;

var builder = WebApplication.CreateBuilder(args);
// Add Infrastructure Service
builder.Services.AddInfrastructure();
// Add Core Service
builder.Services.AddCore();

// Register ValidationFilter
builder.Services.AddScoped(typeof(ValidationFilter<>));

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions
    (options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegisterRequestMappingProfile).Assembly);

//Add API explorer services
builder.Services.AddEndpointsApiExplorer();

//Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "eCommerce UserService API",
        Version = "v1",
        Description = "An API for eCommerce UserService application"
    });
});

//Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
});

//Build the Web application
var app = builder.Build();
app.UseExceptionHandlingMiddleware();

//  Routing
app.UseRouting();

//Add endpoints that can serve the swagger.json
app.UseSwagger();

//Add SwaggerUI(interactive page to explore  and test API endpoints).
app.UseSwaggerUI();

app.UseCors();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//controller routes
app.MapControllers();
app.Run();
