using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Team : IBaseEntity
    {
        public Team()
        {
            this.Players = new List<Player>();
            this.Matches = new List<Match>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }

        public int NumberOfPLayers { get; set; }

        public ICollection<Player> Players { get; set; }

        public Guid LeagueId { get; set; }

        public League League { get; set; }

        public ICollection<Match> Matches { get; set; }

        public int TotalPoints { get; set; }

        public int TotalMatchesCount => this.Matches.Count;
    }
}
