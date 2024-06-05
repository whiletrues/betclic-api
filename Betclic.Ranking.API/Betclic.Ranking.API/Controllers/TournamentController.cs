using Betclic.Ranking.API.Services;
using Betclic.Ranking.Entities.Entities;
using Betclic.Ranking.Entities.Entities.Common.Exceptions;
using Betclic.Ranking.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Betclic.Ranking.API.Controllers
{

    [ApiController]
    public class TournamentController : ControllerBase
    {

        internal readonly TournamentService _tournamentService;

        internal readonly ParticipationService _participationService;
        public TournamentController(
            TournamentService tournamentService, 
            ParticipationService participationService)
        {
            _tournamentService = tournamentService;
            _participationService = participationService;
        }

        [HttpGet("/api/tournaments")]
        public Task<List<Tournament>> List() => _tournamentService.List();


        [HttpPost("/api/tournaments")]
        public async Task<Tournament> Create([FromBody] Tournament tournament)
        {
            var result = await _tournamentService.Create(tournament);

            return result.Match(
                (tournament) => tournament,
                (error) => throw error.ToHttpException());
        }

        [HttpGet("/api/tournaments/{id}")]
        public async Task<Tournament> Get([FromRoute] string? id)
        {
            if (id is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var result = await _tournamentService.Get(id);

            return result.Match(
                (tournament) => tournament,
                (error) => throw error.ToHttpException());
        }


        [HttpGet("/api/tournaments/{id}/ranking")]
        public async Task<List<ParticipationSummary>> Ranking([FromRoute] string? id)
        {
            if (id is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var result = await _participationService.GetRankingByTournament(id);

            return result.Match(
                (ranking) => ranking,
                (error) => throw error.ToHttpException());
        }

    }
}
