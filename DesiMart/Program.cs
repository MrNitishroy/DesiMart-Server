
using DesiMart.DbContext;
using DesiMart.Services;
using DesiMart.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace DesiMart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Mongo Db Confugration 
            builder.Services.Configure<MongoDbConfigs>(builder.Configuration.GetSection("MonogoSetting"));
            builder.Services.AddScoped<MongoDbContext>();
            // Register ProductService
            builder.Services.AddTransient<IProductService, ProductService>();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
