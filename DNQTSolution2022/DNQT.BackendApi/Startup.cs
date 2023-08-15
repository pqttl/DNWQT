using DNQT.BackendApi.Services;
using DNQT.ViewModels.Admin.User;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNQT.BackendApi
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

            #region Enable CORS để front end react gọi được api, còn có 1 cách sửa ở front end bằng cách sửa chrome(cách này đã thử nhưng chưa được)
            //IConfigurationSection myArraySection = Configuration.GetSection("ArrayStringLinkFrontendReact");
            //var itemArray = myArraySection.AsEnumerable();
            string[] arrayStringLinkFrontend = Configuration.GetSection("ArrayStringLinkFrontendReact").Get<string[]>();
            //Sửa arrayStringLinkFrontend ở DNQT.BackendApi\appsettings.json

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder.WithOrigins(arrayStringLinkFrontend)
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                })); 
            #endregion

            #region Khai báo DI
            //Declare DI
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IOrderService, OrderService>(); 
            #endregion

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());


            //Instal Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.28"
            //Thêm lệnh này nếu không sẽ bị lỗi System.Text.Json.JsonException: A possible object cycle was detected ...
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            #region Thêm swagger và JwtBearer

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger DNQT Solution", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Phải thêm lệnh này thì HttpContext.SignInAsync mới có tác dụng lưu thông tin đăng nhập và vào trang chủ
            //Còn không thêm thì nó cứ redirect đến trang login như chưa đăng nhập
            //Nếu không thêm ở dll api thì bị lỗi 401 unauthozied...
            app.UseAuthentication();

            app.UseRouting();

            #region Enable CORS để front end react gọi được api, còn có 1 cách sửa ở front end bằng cách sửa chrome(cách này đã thử nhưng chưa được)
            app.UseCors("MyPolicy");
            #endregion

            app.UseAuthorization();

            #region Thêm swagger và JwtBearer

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger DNQT V1");
            });

            #endregion


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
