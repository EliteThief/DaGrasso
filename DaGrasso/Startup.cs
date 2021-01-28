using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DaGrasso.Data.Interfaces;
using DaGrasso.Data.Models;
using DaGrasso.Data.Repositories;
using DaGrasso.Interfaces;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DaGrasso
{
    public class Startup
    {
        private readonly IConfigurationRoot _configurationRoot;
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>
                    (options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();



            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });


            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IToppingRepository, ToppingRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));


            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy", policy =>
                    policy.RequireClaim("Delete Role"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EditRolePolicy", policy =>
                    policy.RequireClaim("Edit Role"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateRolePolicy",
                    policy =>
                        policy.RequireClaim("Create Role"));
            });


        services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "pizzadetails",
                    pattern: "Home/AddToShoppingCart/{pizzaId?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
            DbInitializer.SeedAsync(serviceProvider);

        }
    }
}
