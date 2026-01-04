using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SurveyBasket.Api.Authentication;
using SurveyBasket.Api.Presistance;
using System.Reflection;
using System.Text;
namespace SurveyBasket.Api
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependancies(this IServiceCollection services, IConfiguration configuration)
        {
            // mean using api
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddFluentValidationsDependancies();
            services.AddMappingDependancies();
            services.AddservicesDependancies();
            services.AddDatabaseDependancies(configuration);
            services.AddAuthDependancies(configuration);

            services.AddSwaggerGen();
            return services;
        }
        public static IServiceCollection AddFluentValidationsDependancies(this IServiceCollection services)
        {
            //add fluent validations 
            services.AddScoped<IValidator, CreatRequestValidator>();
            services.AddFluentValidationAutoValidation()
             .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
        public static IServiceCollection AddMappingDependancies(this IServiceCollection services)
        {
            /// add mapster 
            TypeAdapterConfig mappingConfiguration = TypeAdapterConfig.GlobalSettings;
            mappingConfiguration.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mappingConfiguration));
            return services;
        }
        public static IServiceCollection AddservicesDependancies(this IServiceCollection services)
        {
            // add services 
            services.AddScoped<IPollService, PollService>();

            return services;
        }
        public static IServiceCollection AddDatabaseDependancies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("conf")));

            return services;
        }
        public static IServiceCollection AddAuthDependancies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddIdentity<ApplicationBase, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(option =>
            {
                /// that to attribute auth knew that using Bearer 
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    // that mean singinng key compare 
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f844c97f267ceb6e94eed9afb8124e2e1c3f56ee294fcf5e7b8faa6849f3b707")),
                    ValidIssuer = "SurvayBasketApp",
                    ValidAudience = "SurvayBasketApp Users"
                };
            });
            return services;
        }



    }
}
