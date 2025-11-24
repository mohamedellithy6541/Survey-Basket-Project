using SurveyBasket.Api.Mapping;
using System.Reflection;

namespace SurveyBasket.Api
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependancies(this IServiceCollection services) 
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddFluentValidationsDependancies();
            services.AddMappingDependancies();
            services.AddservicesDependancies();
            
            // add swagger()
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
            services.AddSingleton<IPollService, PollService>();
           return services;
        }
    }
}
