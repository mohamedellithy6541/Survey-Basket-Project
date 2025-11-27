using Microsoft.AspNetCore.Rewrite;

namespace SurveyBasket.Api.Mapping
{
    public class MappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, PollResponse>().Map(d=>d.Notes,s=>s.Summery).TwoWays();
            config.NewConfig<Poll, PollRequest>().TwoWays(); 
        }
    }
}
