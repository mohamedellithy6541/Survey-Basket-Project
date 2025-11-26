using Microsoft.EntityFrameworkCore;

namespace SurveyBasket.Api.Presistance
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) :DbContext(options) 
    {
        public DbSet<Poll>  Polls { get; set; }
    }
}
