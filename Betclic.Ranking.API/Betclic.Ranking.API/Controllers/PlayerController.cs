using Betclic.Ranking.API.Models;
using Betclic.Ranking.API.Services;
using Betclic.Ranking.Entities.Entities;
using Betclic.Ranking.Entities.Entities.Common.Exceptions;
using Betclic.Ranking.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Betclic.Ranking.API.Controllers
{

    [ApiController]
    public class PlayerController : ControllerBase
    {

        internal readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("api/players")]
        public Task<List<Player>> List() => _playerService.List();


        [HttpGet("api/players/{id}")]
        public async Task<Player> Get([FromRoute] string? id)
        {
            if (id is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var result = await _playerService.Get(id);

            return result.Match(
                (player) => player,
                (error) => throw error.ToHttpException());
        }


        [HttpPost("api/players")]
        public async Task<Player> Create([FromBody] Player? player)
        {
            if (player is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var result = await _playerService.Create(player);

            return result.Match(
                (player) => player,
                (error) => throw error.ToHttpException());
        }

        [HttpPut("api/players/{id}")]
        public async Task<Player> Update([FromRoute] string? id, [FromBody] Player? player)
        {
            if (id is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (player is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var result = await _playerService.Update(id, player);

            return result.Match(
                (player) => player,
                (error) => throw error.ToHttpException());
        }

        [HttpDelete("api/players/{id}")]
        public async Task Delete([FromRoute] string? id)
        {
            if (id is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var result = await _playerService.Delete(id);

            if (result.IsOk is false)
                throw result.Error.ToHttpException();
        }

        [HttpGet("/api/players/{id}/participations")]
        public IAsyncEnumerable<Participation> ListParticipationsByPlayerId(string? id)
        {
            if (id is null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return _playerService.ListParticipationsByPlayerId(id);
        }

    }
}
