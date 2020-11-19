using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Create_Table.Models.DBcontext;
using Create_Table.Repository;
using Create_Table.Repository.AddData;
using Create_Table.Service;
using Create_Table.Service.AddData;
using Create_Table.Service.CreateTable;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Create_Table
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
            services.AddControllersWithViews();
            var database = services.AddDbContextPool<AppDBcontext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBContextConnection"));
            });
            services.AddScoped<Ishow,ShowRepository>();
            services.AddScoped<ICreate,AddTable>();
            services.AddScoped<ICheckInput, CheckValueInput>();
            services.AddScoped<ICheckValue,CheckValue>();
            services.AddScoped<IAddData,AddValueToDB>();








        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , AppDBcontext db)
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
            db.Database.EnsureCreated();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
