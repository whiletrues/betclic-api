using Betclic.Ranking.API.Models;
using Betclic.Ranking.API.Repositories;
using Betclic.Ranking.Entities.Entities;
using Betclic.Ranking.Entities.Enums;
using MongoDB.Driver;

namespace Betclic.Ranking.API.Services
{
    public class PlayerService
    {
        private readonly IRepository<string, Player> _playerRepository;

        private readonly ParticipationService _participationService;

        public PlayerService(
            IRepository<string, Player> playerRepository, 
            ParticipationService participationService)
        {
            _playerRepository = playerRepository;
            _participationService = participationService;
        }

        /// <summary>
        /// Retrieves a list of all players.
        /// </summary>
        /// <returns>The list of players.</returns>
        public async Task<List<Player>> List()
        {

            var players = await _playerRepository
                .List()
                .ToListAsync();

            return players is not null
                ? players
                : new List<Player>();
        }

        /// <summary>
        /// Retrieves a player by their ID.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        /// <returns>The player if found, otherwise an error.</returns>
        public async Task<Result<Player, PlayerError>> Get(string? id)
        {
            if (id is null)
                return PlayerError.IdRequired;

            var player = await _playerRepository.Get(id);

            return player is null
                ? PlayerError.NotFound
                : player;
        }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        /// <param name="player">The player to create.</param>
        /// <returns>The created player if successful, otherwise an error.</returns>
        public async Task<Result<Player, PlayerError>> Create(Player player)
        {
            if (player.Name is null)
                return PlayerError.NameRequired;

            return await _playerRepository.Add(player);
        }

        /// <summary>
        /// Updates a player by their ID.
        /// </summary>
        /// <param name="id">The ID of the player to update.</param>
        /// <param name="player">The updated player data.</param>
        /// <returns>The updated player if successful, otherwise an error.</returns>
        public async Task<Result<Player, PlayerError>> Update(string id, Player player)
        {
            if (id is null)
                return PlayerError.IdRequired;

            var updated = await _playerRepository.Update(id, player);

            return updated is null
                ? PlayerError.NotFound
                : updated;
        }

        /// <summary>
        /// Deletes a player by their ID.
        /// </summary>
        /// <param name="id">The ID of the player to delete.</param>
        /// <returns>The ID of the deleted player if successful, otherwise an error.</returns>
        public async Task<Result<string, PlayerError>> Delete(string? id)
        {
            if (id is null)
                return PlayerError.IdRequired;

            await _playerRepository.Delete(id);

            return id;
        }


        public IAsyncEnumerable<Participation> ListParticipationsByPlayerId(string? player)
            => _participationService.ListByPlayerId(player);

        
    }
}
