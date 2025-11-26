using Microsoft.AspNetCore.Rewrite;

namespace SurveyBasket.Api.Mapping
{
    public class MappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Poll, PollResponse>().Map(x=>x.Notes,s=>s.Summery);
            config.NewConfig<Poll, CreatePollRequest>().Map(x => x.Notes, s => s.Summery);
        }
    }
}
