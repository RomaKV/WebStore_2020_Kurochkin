using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.WebStore.DAL;
using Services.WebStore.Infrastructure.Interfaces;
using WebStore.Services;

namespace Services.WebStore.ServicesHosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

           

            services.AddDbContext<WebStoreContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                    
            services.AddSingleton<IEmployeesService, InMemoryEmployeeService>();
            services.AddScoped<IProductService, SqlProductService>();
            services.AddScoped<IOrdersService, SqlOrdersService>();
           // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<ICartService, CookieCartService>();

            // Identity

            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<WebStoreContext>()
               .AddDefaultTokenProviders();

            services.AddTransient<IUserStore<User>, CustomUserStore>();
        
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

       

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
