using System.Text;
using Azure.Storage.Blobs;
using BackendProject.App.Auth.Entities;
using BackendProject.Shared.Persistence.Data;
using BackendProject.Shared.Persistence.SqlConnection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BackendProject.DependencyInjection;

public static class DataBaseDependencyInjection
{
    public static IServiceCollection AddDataBaseConfigs(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
        {
            opts.TokenValidationParameters.ValidateAudience = false;
            opts.TokenValidationParameters.ValidateIssuer = false;
            opts.TokenValidationParameters.IssuerSigningKey
                = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    configuration["BearerToken:Key"]));
        });
        var blobConnectionString = configuration.GetConnectionString("BlobConnection") ??
                                   throw new ArgumentNullException(nameof(configuration));

        services.AddSingleton(u => new BlobServiceClient(blobConnectionString));
        var connectionString = configuration.GetConnectionString(ProjectEnvironment.LocalConnectionString);
        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));
        services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });
        return services;
    }
}