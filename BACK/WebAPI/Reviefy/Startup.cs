using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reviefy.Options;

namespace Reviefy
{
    // class Person
    // {
    //     public string Name { get; set; }
    //     public int Age { get; set; }
    // }
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".Reviefy.Session";
                //options.Cookie.Expiration = TimeSpan.FromSeconds(20);
                options.IdleTimeout = TimeSpan.FromSeconds(1800); // 30 min afk
                options.Cookie.HttpOnly = true;
            });
            
            services.AddLinqToDbContext<AppDataConnection>((provider, options) => {
                options
                    .UseSqlServer(Configuration.GetConnectionString("Default"))
                    .UseDefaultLogging(provider);
            });
            
            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            // app.Run(async (context) =>
            // {
            //     if (context.Request.Cookies.ContainsKey("name"))
            //     {
            //         var name = context.Request.Cookies["name"];
            //         await context.Response.WriteAsync($"Hello {name}!");
            //     }
            //     else
            //     {
            //         context.Response.Cookies.Append("name", "Tom");
            //         await context.Response.WriteAsync("Hello World!");
            //     }
            // });
            
            app.UseSession();   // добавляем механизм работы с сессиями
            // app.Run(async (context) =>
            // {
            //     if(context.Session.Keys.Contains("name"))
            //         await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
            //     else
            //     {
            //         context.Session.SetString("name", "Tom");
            //         await context.Response.WriteAsync("Hello World!");
            //     }
            // });
            // app.Run(async context =>
            // {
            //     if (context.Session.Keys.Contains("person"))
            //     {
            //         var person = context.Session.Get<Person>("person");
            //         await context.Response.WriteAsync($"Hello {person.Name}, your age: {person.Age}!");
            //     }
            //     else
            //     {
            //         var person = new Person { Name = "Tom", Age = 22 };
            //         context.Session.Set("person", person);
            //         await context.Response.WriteAsync("Hello World!");
            //     }
            // });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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