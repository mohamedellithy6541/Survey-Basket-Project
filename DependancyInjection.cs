using System.Reflection;

namespace SurveyBasket.Api
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependancies(this IServiceCollection services) 
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            /// add mapster 
            TypeAdapterConfig mappingConfiguration = TypeAdapterConfig.GlobalSettings;
            mappingConfiguration.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mappingConfiguration));
            
            // add services 
            services.AddSingleton<IPollService, PollService>();
           
            //add fluent validations 
            services.AddScoped<IValidator, CreatRequestValidator>();
            services.AddFluentValidationAutoValidation()
             .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            // add swagger()
            services.AddSwaggerGen();
            
            return services;
        }
    }
}
