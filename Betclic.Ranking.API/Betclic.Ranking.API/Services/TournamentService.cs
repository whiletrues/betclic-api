using Betclic.Ranking.API.Models;
using Betclic.Ranking.API.Repositories;
using Betclic.Ranking.Entities.Entities;
using Betclic.Ranking.Entities.Enums;
using MongoDB.Driver;

namespace Betclic.Ranking.API.Services
{
    public class TournamentService
    {
        private readonly IRepository<string, Tournament> _tournamentRepository;

        public TournamentService(IRepository<string, Tournament> repository)
        {
            _tournamentRepository = repository;
        }

        /// <summary>
        /// Retrieves a list of all tournaments.
        /// </summary>
        /// <returns>A list of tournaments.</returns>
        public async Task<List<Tournament>> List()
        {
            var tournaments = await _tournamentRepository
                .List()
                .ToListAsync();

            return tournaments is not null
                ? tournaments
                : new List<Tournament>();
        }

        /// <summary>
        /// Creates a new tournament.
        /// </summary>
        /// <param name="tournament">The tournament to create.</param>
        /// <returns>A result indicating the success or failure of the operation.</returns>
        public async Task<Result<Tournament, TournamentError>> Create(Tournament tournament)
        {
            if (tournament.Name is null)
                return TournamentError.IdRequired;

            if (tournament.Start < DateTime.Now)
                return TournamentError.InvalidStartDate;

            if (tournament.End < tournament.Start)
                return TournamentError.InvalidEndDate;

            await _tournamentRepository.Add(tournament);

            return tournament;
        }

        public async Task<Result<Tournament, TournamentError>> Get(string id)
        {
            if (id is null)
                return TournamentError.IdRequired;

            var player = await _tournamentRepository.Get(id);

            return player is null
                ? TournamentError.NotFound
                : player;
        }
    }
}
