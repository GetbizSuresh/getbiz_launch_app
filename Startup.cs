using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Repository.Incomplete_Customer_Registration_Data;
using getbiz_launch_app.Repository.User_Profile;
using getbiz_launch_app.Repository.Userapp_App_AccessCopy;
using getbiz_launch_app.Repository.Userapp_User_Category;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using getbiz_launch_app.Repository.Manifest;
using getbiz_launch_app.Repository.Notification;
using WebPush;
using getbiz_launch_app.Repository.UserAppCategoryWiseappaccess;

namespace getbiz_launch_app //lok
{
    public class Startup   //lok
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            String mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<LaunchAppDB_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


            services.AddControllers().AddNewtonsoftJson();
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_launch_app", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                  };
              });
            services.AddMvc();

            services.AddScoped<IIncompleteCustomerRegistrationData, IncompleteCustomerRegistrationData>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserappUserCategoryRepository, UserappUserCategoryRepository>();
            services.AddScoped<IUserappAppAccessCopyRepository, UserappAppAccessCopyRepository>();
            services.AddScoped<IManifestRepository, ManifestRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUserAppCategoryWiseappaccessRepository, UserAppCategoryWiseappaccessRepository>();
            var vapidDetails = new VapidDetails(
             Configuration.GetValue<string>("VapidDetails:Subject"),
             Configuration.GetValue<string>("VapidDetails:PublicKey"),
             Configuration.GetValue<string>("VapidDetails:PrivateKey"));
            services.AddTransient(c => vapidDetails);
            services.AddCors(option => option.AddPolicy("getbiz_launch_app", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_launch_app v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true)
              .AllowCredentials());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }















    }
}
