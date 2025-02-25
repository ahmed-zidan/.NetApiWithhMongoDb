
using Mongo.Api.Extensions;
using Mongo.Infrastructure;
namespace Mongo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            {
                builder.Services.AddApiServices();
                builder.Services.AddInfrastructureServices();
            }
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            {
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
}
