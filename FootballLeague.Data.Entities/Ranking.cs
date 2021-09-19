using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Ranking : IBaseEntity
    {
        public Ranking()
        {
            this.Teams = new List<Team>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Guid LeagueId { get; set; }

        public League League { get; set; }

        public ICollection<Team> Teams { get; set; }

    }
}
