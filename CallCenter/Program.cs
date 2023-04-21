using CallCenter.Middlewares;
using CallCenter.Models;
using CallCenter.Services;
using CallCenter.ServicesImpl;
using CallCenter.Utils.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateTextConverter());
});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(""));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });


    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(e =>
{
    e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(e =>
{
    e.RequireHttpsMetadata = false;
    e.SaveToken = true;
    e.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.....")),
        ValidateAudience = false,
        ValidateIssuer = false,
        //muốn test nhanh thời gian hết hạn token dùng ClockSkew
        ClockSkew = TimeSpan.FromSeconds(10)
    };
});


builder.Services.AddScoped<IAccountService, AccountServiceImpl>();
builder.Services.AddScoped<IClientService, ClientServiceImpl>();
builder.Services.AddScoped<IComplaintService, ComplaintServiceImpl>();
builder.Services.AddScoped<IDepartmentService, DepartmentServiceImpl>();
builder.Services.AddScoped<IOrderClientDetailService, OrderClientDetailServiceImpl>();
builder.Services.AddScoped<IOrderClientService, OrderClientServiceImpl>();
builder.Services.AddScoped<IOrderService, OrderServiceImpl>();
builder.Services.AddScoped<IProductClientService, ProductClientServiceImpl>();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();
builder.Services.AddScoped<IServiceService, ServiceServiceImpl>();
builder.Services.AddScoped<ISendEmailService, SendEmailServiceImpl>();

var app = builder.Build();


app.UseCors(builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials()
                );


app.UseSwagger();
app.UseSwaggerUI(op =>
{
    op.RoutePrefix = "";
    op.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});


app.UseMiddleware<OrderCheckMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
