using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using ShadyNagy.Swagger.Core.Constants;
using ShadyNagy.Swagger.Core.Interfaces;
using ShadyNagy.Swagger.Infrastructure;
using ShadyNagy.Swagger.Infrastructure.Data;
using ShadyNagy.Swagger.Infrastructure.Identity;
using ShadyNagy.Swagger.SharedKernel.Interfaces;

namespace ShadyNagy.Swagger.Api
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string identityConnectionString = Configuration.GetConnectionString("DefaultIdentityConnection");

            services.AddDbContext(connectionString);
            services.AddIdentityDbContext(identityConnectionString);

            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

            var key = Encoding.ASCII.GetBytes(AuthorizationConstants.JWT_SECRET_KEY);
            services.AddAuthentication(config =>
            {
                config.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = false,
                      ValidateAudience = false
                  };
              });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IRepository, EfRepository>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Insert your username and password to access secure api.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OAuth2,
                    Extensions = new Dictionary<string, IOpenApiExtension>
                      {
                        { "x-tokenName", new OpenApiString("token") }
                      },
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("/swagger/api/authenticate", UriKind.Relative),
                        }

                    },
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
                options.InjectStylesheet("/swagger/swagger/ui/style.css");
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
