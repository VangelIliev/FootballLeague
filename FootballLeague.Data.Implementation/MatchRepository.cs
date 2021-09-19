using FootballLeague.Data.Entities;
using FootballLeague.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Implementation
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(FootballLeagueDbContext dbContext) : base(dbContext)
        {

        }

    }
}
