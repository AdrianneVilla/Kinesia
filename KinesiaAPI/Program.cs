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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Load database credentials from .env
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"server={dbHost};port=3306;database={dbName};uid={dbUser};pwd={dbPass}";

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(10, 2, 32))));

            // --- CORS Configuration ---
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy => policy
                        .WithOrigins(
                            "https://kinesia.kiri8tives.com",
                            "http://localhost:5173",
                            "https://localhost:5173"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod());

                options.AddPolicy("ProductionPolicy",
                    policy => policy
                        .WithOrigins("https://kinesia.kiri8tives.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            // --- Kestrel: Try HTTPS, fallback to HTTP ---
            builder.WebHost.ConfigureKestrel(options =>
            {
                try
                {
                    // Try HTTPS (if certificate is trusted/available)
                    options.ListenAnyIP(5001, listenOptions =>
                    {
                        listenOptions.UseHttps(); // Use default dev cert
                    });
                    Console.WriteLine("HTTPS endpoint configured on port 5001");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"HTTPS configuration failed: {ex.Message}");
                    Console.WriteLine("Falling back to HTTP only...");
                }

                // Always ensure HTTP is available
                options.ListenAnyIP(5000);
                Console.WriteLine("HTTP endpoint configured on port 5000");
            });

            var app = builder.Build();

            // --- Middleware ---
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Try HTTPS redirection, but skip if no cert is valid
            try
            {
                app.UseHttpsRedirection();
            }
            catch
            {
                Console.WriteLine("HTTPS redirection skipped (no valid certificate)");
            }

            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
                app.UseCors("AllowLocalhost");
            else
                app.UseCors("ProductionPolicy");

            app.MapControllers();
            app.Run();
        }
    }
}
