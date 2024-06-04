
using Betclic.Ranking.Entities.Entities.Common.Exceptions;

namespace Betclic.Ranking.Entities.Enums
{
    public enum PlayerError
    {
        /// <summary>
        /// Player not found
        /// </summary>
        NotFound = 0,

        /// <summary>
        /// Player already exists
        /// </summary>
        AlreadyExists = 1,

        /// <summary>
        /// Player name is required
        /// </summary>
        NameRequired = 2,

        /// <summary>
        /// Player id is required
        /// </summary>
        IdRequired = 3
    }

}
