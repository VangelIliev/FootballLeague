using FootballLeague.Data.Entities;
using FootballLeague.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FootballLeagueDbContext Context;
        public UnitOfWork(FootballLeagueDbContext context)
        {
            this.Context = context;
            Leagues = new LeagueRepository(Context);
            Matches = new MatchRepository(Context);
            Players = new PlayerRepository(Context);
            Rankings = new RankingRepository(Context);
            Teams = new TeamRepository(Context);
        }
        public ILeagueRepository Leagues { get; private set; }

        public IMatchRepository Matches { get; private set; }

        public IPlayerRepository Players { get; private set; }

        public IRankingRepository Rankings { get; private set; }

        public ITeamRepository Teams { get; private set; }

        public async Task<int> Complete()
        {
            return await Context.SaveChangesAsync();
        }

        public void  Dispose()
        {
            Context.Dispose();
        }
    }
}
