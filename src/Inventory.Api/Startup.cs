using Inventory.Core;
using Inventory.Data;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Inventory.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        #region Configurations
        services.AddDbContextConfiguration(Configuration);
        services.AddIdentityConfiguration();
        services.AddAuthenticationConfiguration(Configuration);

        services.AddCors();

        services.AddHttpContextAccessor();

        services.AddControllersConfigurations();    
        services.AddSwaggerConfigurations();
        #endregion

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddEntitiesServices();
        services.AddAutoMapper(typeof(Startup));
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}
