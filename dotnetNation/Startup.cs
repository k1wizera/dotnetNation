using dotnetNation.Data;
using dotnetNation.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace dotnetNation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IRepository, Repository>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
        }
    }
}