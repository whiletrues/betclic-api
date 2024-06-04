using Betclic.Ranking.API.Models;
using Betclic.Ranking.API.Repositories;
using Betclic.Ranking.API.Services;
using Betclic.Ranking.Entities.Entities;
using MongoDB.Driver;

namespace Betclic.Ranking.API.Configuration.Dependecy
{
    public static class ServiceExtensions
    {
        public static void AddServicesDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRankingDatabase(configuration)
                .AddRepositories()
                .AddSingleton<PlayerService>()
                .AddSingleton<TournamentService>()
                .AddSingleton<ParticipationService>();
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton<IRepository<string, Player>, PlayerRespository>()
                .AddSingleton<IRepository<string, Tournament>, TournamentRepository>()
                .AddSingleton<IRepository<string, Participation>, ParticipationRepository>();
        }

        public static IServiceCollection AddRankingDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["RankingDatabase:ConnectionString"];
            var databaseName = configuration["RankingDatabase:DatabaseName"];

            var mongoClient = new MongoClient(connectionString);

            var database = mongoClient.GetDatabase(databaseName);

            services.AddSingleton<IMongoDatabase>(database);

            return services;

        }
    }
}
