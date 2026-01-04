using Microsoft.AspNetCore.Rewrite;
using SurveyBasket.Api.Contracts.Poll.Request;
using SurveyBasket.Api.Contracts.Poll.Response;

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
