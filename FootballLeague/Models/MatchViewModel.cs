using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class MatchViewModel
    {
        public Guid Id { get; set; }
        public Guid LeagueId { get; set; }

        public Guid HomeTeamId { get; set; }
        
        public Guid AwayTeamId { get; set; }

        //If 1 home team won if 2 away team won if 0 draw
        public int Outcome { get; set; }

        public DateTime GameStarted { get; set; }

        public DateTime GameFinished { get; set; }
    }
}
