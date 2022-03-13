using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FlightMobileApp.Models;

namespace FlightMobileApp
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
            services.AddSingleton(typeof(Model), typeof(Model));
            /**
            string ip = Configuration.GetValue<string>("ConnectSetting:Ip");
            string httpPort = Configuration.GetValue<string>("ConnectSetting:HttpPort");
            string telnetClientPort = Configuration.GetValue<string>("ConnectSetting:TelnetClientPort");
            TelnetClient tel = new TelnetClient();
            Model modeli = new Model(tel);
            services.AddControllers();
            services.AddSingleton(tel);
            services.AddSingleton(modeli);
        */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
