using Betclic.Ranking.API.Models;

namespace Betclic.Ranking.API.Repositories
{
    public interface IRepository<I, T>
    {
        public Task<T> Add(T value);

        public Task<T> Update(I id, T value);

        public Task Delete(I id);

        public Task<T> Get(I id);

        public IAsyncEnumerable<T> List();

    }
}
