
using KinesiaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KinesiaAPI
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(10, 2, 32))));

            //Cors Configuration
            builder.Services.AddCors(options =>
            {
               options.AddPolicy("AllowLocalhost",
                   policy => policy
                       .WithOrigins("https://localhost:5173", "http://localhost:5173")
                      .AllowAnyHeader()
                      .AllowAnyMethod());

                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("https://localhost:5173", "http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });


          
            builder.Services.AddControllers();
            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowLocalhost");
            app.UseCors("AllowReactApp");
            app.MapControllers();

            app.Run();
        }
    }
}
