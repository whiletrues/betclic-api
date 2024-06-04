using Betclic.Ranking.Entities.Entities.Common.Exceptions;

namespace Betclic.Ranking.Entities.Enums
{
    public static class Extensions
    {
        /// <summary>
        /// Convert a TournamentError to an HttpResponseException
        /// </summary>
        /// <param name="tournamentError"></param>
        /// <returns>A new instance of HttpResponseException</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static HttpResponseException ToHttpException(this TournamentError tournamentError)
        {
            return tournamentError switch
            {
                TournamentError.InvalidStartDate => new HttpResponseException(System.Net.HttpStatusCode.BadRequest),
                TournamentError.InvalidEndDate => new HttpResponseException(System.Net.HttpStatusCode.BadRequest),
                TournamentError.IdRequired => new HttpResponseException(System.Net.HttpStatusCode.BadRequest),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Convert a PlayerError to an HttpResponseException
        /// </summary>
        /// <param name="playerError"></param>
        /// <returns>A new instance of HttpResponseException</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static HttpResponseException ToHttpException(this PlayerError playerError)
        {
            return playerError switch
            {
                PlayerError.NotFound => new HttpResponseException(System.Net.HttpStatusCode.NotFound),
                PlayerError.AlreadyExists => new HttpResponseException(System.Net.HttpStatusCode.Conflict),
                PlayerError.NameRequired => new HttpResponseException(System.Net.HttpStatusCode.BadRequest),
                PlayerError.IdRequired => new HttpResponseException(System.Net.HttpStatusCode.BadRequest),
                _ => throw new NotImplementedException()
            };
        }


        public static ParticipationError ToParticipationError(this PlayerError error)
        {
            return error switch
            {
                PlayerError.NotFound => ParticipationError.PlayerNotFound,
                _ => throw new NotImplementedException()
            };
        }

        public static ParticipationError ToParticipationError(this TournamentError error)
        {
            return error switch
            {
                TournamentError.NotFound => ParticipationError.TournamentNotFound,
                _ => throw new NotImplementedException()
            };
        }
    }
}
