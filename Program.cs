
using System.Reflection;

namespace SurveyBasket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            TypeAdapterConfig mappingConfiguration = TypeAdapterConfig.GlobalSettings;
            mappingConfiguration.Scan(Assembly.GetExecutingAssembly());

            builder.Services.AddSingleton<IMapper>(new Mapper(mappingConfiguration));

            builder.Services.AddSingleton<IPollService, PollService>();

            builder.Services.AddScoped<IValidator, CreatRequestValidator>();
            builder.Services.
             AddFluentValidationAutoValidation()
             .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"));

            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
