using Aqary.Core.Manager;
using Aqary.Core.Manager.Interface;
using Aqary.Core.Mapper;
using Aqary.DataAccessLayer.Models;
using AutoMapper;
using examBaraaDb.Exceptions;
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
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Aqary.Factory;

namespace Aqary
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new Maping());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AqaryDataBaseContext>(
                options => options.
                UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling
            = ReferenceLoopHandling.Ignore);



            services.AddSingleton(
                _mapperConfiguration.CreateMapper());
            //services.AddScoped<ICategoryManager, CategoryManager>();
            //services.AddScoped<IUserManager, UserManager>();
            //services.AddScoped<IEstateManager, EstateManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aqar", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please insert Bearer JWT token,Example:'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issure"],
                       ValidAudience = Configuration["Jwt:Issure"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });
            ApiFactory.RegisterDependencies(services); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aqary v1"));
            }
            app.UseCors(x=> x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureExceptionHandler(Log.Logger, env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
