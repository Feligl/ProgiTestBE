using API.Interfaces;
using API.Services;
using API.Utilities;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var _appSettingsReader = new AppSettingsReader();
            var CorsPolicy = "Cors";

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Docs",
                    Description = "A small documentation of the backend API",
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                                  builder =>
                                  {
                                      builder.WithOrigins(_appSettingsReader.GetValue<string>("AllowedOrigins"));
                                  });
            });

            builder.Services.AddScoped<IVehicleAuctionService, VehicleAuctionService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseCors(CorsPolicy);
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}