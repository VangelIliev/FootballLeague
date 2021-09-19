using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public int NumberOfPLayers { get; set; }
       
        public Guid LeagueId { get; set; }
        
        public int TotalPoints { get; set; }
       
    }
}
