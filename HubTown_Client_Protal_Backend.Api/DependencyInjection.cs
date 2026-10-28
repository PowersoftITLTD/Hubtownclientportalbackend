using HubTown_Client_Protal_Backend.Api.Application.Interfaces;
using HubTown_Client_Protal_Backend.Api.Application.Services;
using HubTown_Client_Protal_Backend.Api.Domain.IRepositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Common.Persistence;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Repositories;
using HubTown_Client_Protal_Backend.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace HubTown_Client_Protal_Backend.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthsService, AuthsService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IKYCService, KYCService>();
            services.AddScoped<ITDSService, TDSService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ISendService, SendGridService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            return services;
        }

        // Add a new method to handle JWT configuration
        private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
                    ValidAudience = jwtSettings.GetValue<string>("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddInfrastructureServices()
                .AddPersistence(configuration)
                .AddJwtAuthentication(configuration); // Add this line
            return services;
        }

        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ICommonService, CommonService>();
            services.AddSingleton<IDocument, Document>();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MVC6CrudConnetionString")));
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthsRepository, AuthsRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IKYCRepository, KYCRepository>();
            services.AddScoped<ITDSRepository, TDSRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            return services;
        }

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // Add Swagger configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hubtown Client Portal Backend Api", Version = "v1" });

                // Add JWT Bearer Security Definition
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Add Security Requirement
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
                        new string[] {}
                    }
                });
            });

            services.AddProblemDetails();
            return services;
        }
    }
}
