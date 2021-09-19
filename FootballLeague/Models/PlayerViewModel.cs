using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class PlayerViewModel
    {
        public string Name { get; set; }

        public int JurseyNumber { get; set; }

        public Guid TeamId { get; set; }
    }
}
