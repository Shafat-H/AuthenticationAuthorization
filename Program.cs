using AspNetCoreRateLimit;
using AuthenticationAuthorization;
using AuthenticationAuthorization.DbContexts;
using AuthenticationAuthorization.IRepository;
using AuthenticationAuthorization.Repository;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddHttpContextAccessor();

// Register IMemoryCache explicitly
builder.Services.AddMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);

// Register the rate limiting services
builder.Services.AddInMemoryRateLimiting();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();



// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            // Specify the expected issuer and audience
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
            ClockSkew = TimeSpan.Zero // Optional: to avoid expiration issues
        };
    });


builder.Services.AddSwaggerService();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
//{
//    builder.RegisterType<AppUsers>().As<IAppUsers>();

//}
DependencyContainer.ConfigureContainer(builder)
);



var app = builder.Build();

app.UseIpRateLimiting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger(c =>
    //{
    //    c.RouteTemplate = "AuthenticationAuthorization/swagger/{documentName}/swagger.json";
    //});
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/AuthenticationAuthorization/swagger/v1/swagger.json", "Authentication Authorization");
    //    c.RoutePrefix = "AuthenticationAuthorization/swagger";
    //});

    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
