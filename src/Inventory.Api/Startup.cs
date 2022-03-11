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
        #endregion

        services.AddCors();

        services.AddControllers()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
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

        app.UseAuthorization();
        app.UseAuthorization();

        app.MapControllers();
    }
}
