using Betclic.Ranking.API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Betclic.Ranking.API.Repositories
{
    public class PlayerRespository : IRepository<string, Player>
    {
        private readonly IMongoCollection<Player> _playersCollection;

        public PlayerRespository(IMongoDatabase database)
        {
            _playersCollection = database.GetCollection<Player>("Players");
        }

        public async Task<Player> Add(Player player)
        {
            await _playersCollection.InsertOneAsync(player);

            return player;
        }
        public Task<Player> Update(string id, Player player)
        {
            var filter = Builders<Player>
                .Filter
                .Eq("_id", ObjectId.Parse(id));

            var operation = Builders<Player>
                .Update
                .Set("name", player.Name);

            return _playersCollection.FindOneAndUpdateAsync(filter, operation);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<Player>
                .Filter
                .Eq("_id", ObjectId.Parse(id));

            await _playersCollection.DeleteOneAsync(filter);
        }

        public async Task<Player?> Get(string id)
        {
            var filter = Builders<Player>
                .Filter
                .Eq("_id", ObjectId.Parse(id));

            var players = await _playersCollection
                .Find(filter)
                .ToListAsync() ?? new List<Player>();


            return players?.FirstOrDefault();
        }

        public async IAsyncEnumerable<Player> List()
        {
            using (var cursor = await _playersCollection.FindAsync(_ => true))
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
    }
}
