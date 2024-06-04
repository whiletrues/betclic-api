using Betclic.Ranking.API.Models;
using Betclic.Ranking.API.Repositories;
using Betclic.Ranking.Entities.Entities;
using Betclic.Ranking.Entities.Enums;

namespace Betclic.Ranking.API.Services
{
    public class ParticipationService
    {
        internal readonly TournamentService _tournamentService;

        private readonly IRepository<string, Participation> _participationRepository;

        public ParticipationService(
            IRepository<string, Participation> repository,
            TournamentService tournamentService)
        {
            _participationRepository = repository;
            _tournamentService = tournamentService;
        }

        public async Task<Result<Participation, ParticipationError>> Create(Participation participation)
        {
            await _participationRepository.Add(participation);

            return participation;
        }

        public IAsyncEnumerable<Participation> ListByPlayerId(string? player)
        {
            var specializedRepository = _participationRepository as ParticipationRepository;

            return specializedRepository.ListByPlayerId(player);
        }


        public async Task<Result<List<ParticipationSummary>, ParticipationError>> GetRankingByTournament(string? tournament)
        {
            var specializedRepository = _participationRepository as ParticipationRepository;

            if (tournament is null)
                return ParticipationError.TournamentNotFound;
            
            var summary = await specializedRepository.GetRankingByTournament(tournament);

            if (summary is null)
                return ParticipationError.TournamentNotFound;

            return summary;

        }
    }
}
