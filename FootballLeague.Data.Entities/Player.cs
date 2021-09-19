using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class Player : IBaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Range(1,99)]
        public int JurseyNumber { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }
    }
}
