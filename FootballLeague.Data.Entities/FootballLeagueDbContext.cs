using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext()
        {

        }
        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options)
            : base(options)
        {
        }
        public DbSet<League> Leagues { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Ranking> Rankings { get; set; }

        public DbSet<Team> Teams { get; set; }
       
    }
}
