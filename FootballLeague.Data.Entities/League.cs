using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class League : IBaseEntity
    {
        public League()
        {
            this.Teams = new List<Team>();
            this.Matches = new List<Match>();
        }
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string LeagueName { get; set; }

        public int RegisteredTeams { get; set; }

        public Guid RankingId { get; set; }

        public Ranking Ranking { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
