using eCommerce.API.Filters;
using eCommerce.ProductService.BusinessLogicLayer;
using eCommerce.ProductService.DataAccessLayer;
using eCommerce.ProductsMicroService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();
// Register ValidationFilter
builder.Services.AddScoped(typeof(ValidationFilter<>));


//Add API explorer services
builder.Services.AddEndpointsApiExplorer();

//Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "eCommerce ProductService API",
        Version = "v1",
        Description = "An API for eCommerce ProductService application"
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

//Add API explorer services
builder.Services.AddEndpointsApiExplorer();

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
