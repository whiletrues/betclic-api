namespace Betclic.Ranking.API.Repositories
{
    public static class Extensions
    {

        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> source)
        {
            var list = new List<T>();
            await foreach (var item in source)
            {
                list.Add(item);
            }
            return list;
        }

    }
}
