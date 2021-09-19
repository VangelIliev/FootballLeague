using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class LeagueViewModel
    {
        public string LeagueName { get; set; }

        public int RegisteredTeams { get; set; }

        public Guid RankingId { get; set; }

    }
}
