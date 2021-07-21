using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace project
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
            string path = Directory.GetCurrentDirectory(); //取得路徑
            services.AddDbContext<ContactContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BookingContext").Replace("[DataDirectory]",path))); //註冊及取代字串
          
            services.AddScoped<IDataAccess, DataAccess>(); //註冊DataAccess
            services.AddScoped<IBackstage, Backstage>(); //註冊Backstage
            services.AddDbContext<UserContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BookingContext").Replace("[DataDirectory]", path)));
            
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                //瀏覽器會限制cookie 只能經由HTTP(S) 協定來存取
                option.Cookie.HttpOnly = true;
                //登入頁，未登入時會自動導到登入頁
                option.LoginPath = new PathString("/Backstage/Index");
            });

            services.AddDbContext<RoomContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BookingContext").Replace("[DataDirectory]", path)));
            //啟用Session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //在view 裡面使用session  @inject IHttpContextAccessor, HttpContextAccessor @using Microsoft.AspNetCore.Http;
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<IntroductionContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BookingContext").Replace("[DataDirectory]", path)));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<EmployeeContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BookingContext").Replace("[DataDirectory]", path)));

            services.AddDbContext<AboutUsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BookingContext").Replace("[DataDirectory]", path)));
        }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            //啟用 cookie 原則功能
            app.UseCookiePolicy();
            app.UseAuthentication();//驗證
            app.UseAuthorization();
            app.UseSession();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                            });
            
        }
    }
}
    
