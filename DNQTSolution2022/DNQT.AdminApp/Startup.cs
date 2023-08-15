using DNQT.AdminApp.Services;
using DNQT.ViewModels.Admin.User;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNQT.AdminApp
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

            #region Thiet lap redirect den trang login khi chua dang nhap
            //Thiet lap redirect den trang login khi chua dang nhap
            string strTemp = nameof(DNQT.AdminApp.Controllers.LoginController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            string strActionLogin = nameof(DNQT.AdminApp.Controllers.LoginController.Index);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = $"/{strController}/{strActionLogin}/";
                    options.AccessDeniedPath = "/User/Forbidden/";
                });
            #endregion


            #region Su dung fluent validation 
            //Su dung fluent validation
            services.AddControllersWithViews()
    //            .AddNewtonsoftJson(options =>
    //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//)
                     .AddFluentValidation(
                fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

//            services.AddControllers().AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);
            #endregion

            #region Thiết lập thông số khi sử dụng session
            services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(10);
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion


            #region Injection gan gia tri cho interface
            //Injection gan gia tri cho interface
            services.AddHttpClient();
            services.AddTransient<IOrderApiClient, OrderApiClient>();
            services.AddTransient<ILoginApiClient, LoginApiClient>();
            services.AddTransient<IUserApiClient, UserApiClient>(); 
            services.AddTransient<IStatisticApiClient, StatisticApiClient>(); 
            services.AddTransient<IViewRenderService, ViewRenderService>(); 
            #endregion

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Phải thêm lệnh này thì HttpContext.SignInAsync mới có tác dụng lưu thông tin đăng nhập và vào trang chủ
            //Còn không thêm thì nó cứ redirect đến trang login như chưa đăng nhập
            //Nếu không thêm ở dll api thì bị lỗi 401 unauthozied...
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            #region Thiết lập thông số khi sử dụng session
            app.UseSession(); 
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
