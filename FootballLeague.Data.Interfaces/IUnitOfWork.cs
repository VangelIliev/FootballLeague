using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILeagueRepository Leagues { get; }
        IMatchRepository Matches { get; }
        IPlayerRepository Players { get; }
        IRankingRepository Rankings { get; }

        ITeamRepository Teams { get; }

        Task<int> Complete();
    }
}
