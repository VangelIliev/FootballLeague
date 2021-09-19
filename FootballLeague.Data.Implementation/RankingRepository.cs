using FootballLeague.Data.Entities;
using FootballLeague.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Implementation
{
    public class RankingRepository : Repository<Ranking>,IRankingRepository
    {
        public RankingRepository(FootballLeagueDbContext dbContext) : base(dbContext)
        {

        }
    }
}
