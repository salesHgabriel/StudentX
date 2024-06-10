using Asp.Versioning;
using Companyx.Companyx.Studentx.Application.Abstractions.Data;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Users;
using Companyx.Companyx.Studentx.Infrastructure.Authentication;
using Companyx.Companyx.Studentx.Infrastructure.Data;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShortCleanLinqExtensions.src.Extensions;
using System.Text;

namespace Companyx.Companyx.Studentx.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            var appSettingSection = configuration.GetSection("JwtBearerSettings");
            services.Configure<JwtBearerSettings>(appSettingSection);

            var appSetting = appSettingSection.Get<JwtBearerSettings>() ?? throw new ArgumentNullException("authetication settings not found");
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(auth =>
            {

                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(auth =>
              {
                  auth.RequireHttpsMetadata = true;
                  auth.SaveToken = true;
                  auth.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = appSetting.Audience,
                      ValidIssuer = appSetting.Issuer
                  };
              });

            services.AddDIScannerIOCWithScrutor();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var connectionString = configuration.GetConnectionString("DatabasePostgreSql") ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1);
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'V";
                opt.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}