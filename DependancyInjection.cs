using Microsoft.EntityFrameworkCore;
using SurveyBasket.Api.Presistance;
using System.Reflection;

namespace SurveyBasket.Api
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependancies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddFluentValidationsDependancies();
            services.AddMappingDependancies();
            services.AddservicesDependancies();

            // add swagger()
            services.AddSwaggerGen();

            services.AddDatabaseDependancies(configuration);
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
       
        public static IServiceCollection AddDatabaseDependancies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("conf")));

            return services;
        }
        


    }
}
