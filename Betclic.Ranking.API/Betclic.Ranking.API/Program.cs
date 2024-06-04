using Betclic.Ranking.API.Configuration.Dependecy;
using Betclic.Ranking.API.Configuration.Filters;

namespace Betclic.Ranking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder
                .Services
                .Configure<RankingDatabaseSettings>(builder.Configuration.GetSection("RankingDatabase"))
                .AddServicesDependency(builder.Configuration);

            builder
                .Services
                .AddControllers(options =>
                {
                    options.Filters.Add<HttpResponseExceptionFilter>();
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            builder.Services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
