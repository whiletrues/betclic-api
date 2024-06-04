using Betclic.Ranking.API.Services;
using Betclic.Ranking.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Betclic.Ranking.API.Controllers
{
    [ApiController]
    public class ParticipationController : ControllerBase
    {

        internal readonly ParticipationService _participationService;

        public ParticipationController(ParticipationService participationService)
        {
            _participationService = participationService;
        }


        [HttpPost("/api/participations")]
        public async Task<Participation> Participation([FromBody] Participation participation)
        {
            var result = await _participationService.Create(participation);

            return result.Match(
                (participation) => participation,
                (error) => throw new Exception(error.ToString())
            );
        }
    }
}
