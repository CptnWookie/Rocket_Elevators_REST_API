using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RocketApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace RocketApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            try
            {
                Console.WriteLine("Bloc config");
                services.AddControllers().AddNewtonsoftJson();


                services.AddDbContext<RocketContext>(opt =>
            opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            }


            catch (Exception ex)
            {
                Console.WriteLine("Erreur BD", ex);
            }

            //     services.AddDbContext<RocketContext>(options =>
            //options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            //   options.UseMySql("server=localhost;port=3306;database=app_development;uid=root;password=SimpleYellow"));

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
