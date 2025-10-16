
using KinesiaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KinesiaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"server={dbHost};port=3306;database={dbName};uid={dbUser};pwd={dbPass}";

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(10, 2, 32))));

            //Cors Configuration
            builder.Services.AddCors(options =>
            {
               options.AddPolicy("AllowLocalhost",
                   policy => policy
                       .WithOrigins("https://localhost:5173", "http://localhost:5173")
                      .AllowAnyHeader()
                      .AllowAnyMethod());

                options.AddPolicy("ProductionPolicy",
                   policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
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

            if (app.Environment.IsDevelopment())
            {
                // Only use the localhost policy when developing
                app.UseCors("AllowLocalhost");
            }
            else
            {
                // Use the flexible policy when on the live server
                app.UseCors("ProductionPolicy");
            }
            app.MapControllers();

            app.Run();
        }
    }
}
