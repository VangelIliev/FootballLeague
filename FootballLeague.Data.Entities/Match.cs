using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Match : IBaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid LeagueId { get; set; }
        [Required]
        public League League { get; set; }
        [Required]
        public Guid HomeTeamId { get; set; }
        [Required]
        public Team HomeTeam { get; set; }
        [Required]
        public Guid AwayTeamId { get; set; }
        [Required]
        public Team AwayTeam { get; set; }

        //If 1 home team won if 2 away team won if 0 draw
        public int Outcome { get; set; }

        public DateTime GameStarted { get; set; }

        public DateTime GameFinished { get; set; }


    }
}
