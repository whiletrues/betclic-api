using Betclic.Ranking.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Betclic.Ranking.API.Repositories
{
    public class TournamentRepository : IRepository<string, Tournament>
    {
        private readonly IMongoCollection<Tournament> _collection;

        public TournamentRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Tournament>("tournaments");
        }

        public async Task<Tournament> Add(Tournament value)
        {
            await _collection.InsertOneAsync(value);
            return value;
        }

        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tournament> Get(string id)
        {
            var filter = Builders<Tournament>
                .Filter
                .Eq("_id", ObjectId.Parse(id));

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async IAsyncEnumerable<Tournament> List()
        {
            using (var cursor = await _collection.FindAsync(_ => true))
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var tournament in cursor.Current)
                    {
                        yield return tournament;
                    }
                }
            }
        }

        public async Task<Tournament> Update(string id, Tournament value)
        {
            throw new NotImplementedException();
        }
    }
}
