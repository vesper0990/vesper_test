using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace vesper_test
{
    public class Startup
    {
		
		private readonly string _connectionString;
		
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
			_connectionString = @"Server=db; Database=Students; Uid=user_name_1; Pwd=my-secret-pw";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            WaitForDBInit(_connectionString);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
		
		private static void WaitForDBInit(string connectionString)
        {
			Console.WriteLine("WaitForDBInit");
            // var connection = new MySqlConnection(connectionString);
            // int retries = 1;
            // while (retries < 7)
            // {
                // try
                // {
                    // Console.WriteLine("Connecting to db. Trial: {0}", retries);
                    // connection.Open();
                    // connection.Close();
                    // break;
                // }
                // catch (MySqlException)
                // {
                    // Thread.Sleep((int) Math.Pow(2, retries) * 1000);
                    // retries++;
                // }
            // }
        }
    }
}
