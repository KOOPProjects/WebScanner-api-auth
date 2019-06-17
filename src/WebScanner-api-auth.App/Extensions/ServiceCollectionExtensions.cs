﻿using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Repositories;
using WebScanner_api_auth.Infrastructure.DataContexts;
using WebScanner_api_auth.Infrastructure.Dtos.Settings;
using WebScanner_api_auth.Infrastructure.Handlers;
using WebScanner_api_auth.Infrastructure.Models;
using WebScanner_api_auth.Infrastructure.Repositories;

namespace WebScanner_api_auth.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabaseServices(this IServiceCollection services)
        {
            const string connectionString =
               @"User ID=webscanner;Password=eCCxufUi3KmZX4DRuxDpdpZZFO8qJm8G;Host=s2.ptrd.pl;Port=5432;Database=webscanner;Pooling=true;";
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString));
            services.AddIdentity<WebScannerUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>();
        }

        public static void AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "WBT.Identity Application Interface",
                    Description = "Api for providing authentication features",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Oskar Przybylski", Email = "przybylski.oskar@gmail.com", Url = "o-and-m.mattszczesny.com" }
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });
        }

        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            var appSettingsSection = configuration.GetSection("AuthorizationSettings");
            services.Configure<AuthorizationSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AuthorizationSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<UserManager<WebScannerUser>>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetUserAsync(context.Principal);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
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
            
            
        }

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(LoginCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RegisterCommandHandler).GetTypeInfo().Assembly);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
        }

    }
}
