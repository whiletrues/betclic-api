
using Betclic.Ranking.Entities.Entities;
using MongoDB.Driver;

namespace Betclic.Ranking.API.Repositories
{
    public class ParticipationRepository : IRepository<string, Participation>
    {

        private readonly IMongoCollection<Participation> _participationCollection;

        public ParticipationRepository(IMongoDatabase database)
        {
            _participationCollection = database.GetCollection<Participation>("Participations");
        }

        public async Task<Participation> Add(Participation value)
        {
            await _participationCollection.InsertOneAsync(value);

            return value;
        }

        public Task Delete(string id)
            => throw new NotImplementedException();


        public Task<Participation> Get(string id)
            => throw new NotImplementedException();


        public IAsyncEnumerable<Participation> List()
            => throw new NotImplementedException();


        public Task<Participation> Update(string id, Participation value)
            => throw new NotImplementedException();

        public async IAsyncEnumerable<Participation> ListByPlayerId(string? player)
        {
            var filter = Builders<Participation>
                .Filter
                .Eq("player", player);

            using (var cursor = await _participationCollection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var participation in cursor.Current)
                    {
                        yield return participation;
                    }
                }
            }
        }

        public Task<List<ParticipationSummary>> GetRankingByTournament(string? tournament)
        {

            var filter = Builders<Participation>
                .Filter
                .Eq("tournament", tournament);

            return _participationCollection
                .Aggregate()
                .Match(filter)
                .Group(
                (p) => p.Player,
                (grouping) => new
                {
                    player = grouping.Key,
                    points = grouping.Sum(p => p.Points)
                })
                .SortBy(tuple => tuple.points)
                .Project(tuple => new ParticipationSummary
                {
                    Tournament = tournament,
                    Player = tuple.player,
                    Points = tuple.points
                })
                .ToListAsync();
        }


    }
}
