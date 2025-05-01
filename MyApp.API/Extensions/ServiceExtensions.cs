using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data;

namespace MyApp.API.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Enable CORS，阻止來自不同網域的請求，Configure需加入
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(builder =>
                builder.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            );
        }

        /// <summary>
        /// EntityFrameworkCore
        /// </summary>
        /// <param name="services"></param>
        /// <param name=""></param>
        public static void ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<_DbContext>(builder =>
            {
                // 設定遷移元件
                builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
