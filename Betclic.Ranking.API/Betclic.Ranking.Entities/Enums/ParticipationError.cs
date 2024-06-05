using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betclic.Ranking.Entities.Enums
{
    public enum ParticipationError
    {
        /// <summary>
        /// The player was not found.
        /// </summary>
        PlayerNotFound = 0,
        

        /// <summary>
        /// The tournament was not found.
        /// </summary>
        TournamentNotFound = 1,


        TournamentRequired = 2
    }
}
