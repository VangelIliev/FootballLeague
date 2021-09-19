using FootballLeague.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeague.Data.Entities;
using FootballLeague.Models;

namespace FootballLeague.Controllers
{
    [Authorize]
    [ApiController]
    [Route("FootballLeague")]
    //Само толкова успях да направя не ми стигна времето уикенда.
    public class FootballLeagueController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FootballLeagueController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("SaveLeague")]
        public async Task<ActionResult<League>> SaveLeague(LeagueViewModel model)
        {
            var league = new League
            {
                LeagueName = model.LeagueName,
                RankingId = Guid.NewGuid(),
                RegisteredTeams = 12
            };
            await this._unitOfWork.Leagues.CreateAsync(league);
            await this._unitOfWork.Complete();
            return league;
        }

        [HttpPost]
        [Route("CreateTeam")]
        public async Task<ActionResult<Team>> CreateTeam(TeamViewModel model)
        {
            var leagues = await this._unitOfWork.Leagues.FindAllAsync();
            var firstLeague = leagues.FirstOrDefault();
            if (firstLeague == null)
            {
                return NotFound();
            }

            var team = new Team
            {
                LeagueId = firstLeague.Id,
                TotalPoints = 0
            };
            await this._unitOfWork.Teams.CreateAsync(team);

            return team;
        }
        [HttpDelete]
        [Route("DeleteTeam")]
        public async Task<ActionResult<Team>> DeleteTeam(Guid teamId)
        {
            var Team = await this._unitOfWork.Teams.ReadAsync(teamId);
            if (Team != null)
            {
                await this._unitOfWork.Matches.DeleteAsync(Team.Id);
                return Team;
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetAllTeams")]
        public async Task<ActionResult<ICollection<Team>>> GetAllTeams(Guid leagueId)
        {
            var allTeams = await this._unitOfWork.Teams.FindAllAsync();
            if (allTeams.Any())
            {
                var filteredTeams = allTeams.Where(x => x.LeagueId == leagueId).ToList();
                return allTeams;
            }
            return NotFound();

        }
        [HttpPut]
        [Route("UpdateTeam")]
        public async Task<ActionResult<Team>> UpdateMatch(TeamViewModel team)
        {
            var Team = await this._unitOfWork.Teams.ReadAsync(team.Id);
            if (Team != null)
            {
                Team.LeagueId = team.LeagueId;
                Team.NumberOfPLayers = team.NumberOfPLayers;
                await this._unitOfWork.Teams.UpdateAsync(Team);
                return Team;
            }
            return NotFound();
        }
        [HttpPost]
        [Route("CreateMatch")]
        public async Task<ActionResult<Match>> CreateMatch(MatchViewModel model)
        {
            var match = new Match
            {
                AwayTeamId = model.AwayTeamId,
                HomeTeamId = model.HomeTeamId,
                GameStarted = DateTime.Now,
                GameFinished = DateTime.Now.AddHours(1),
                LeagueId = model.LeagueId,
                Outcome = model.Outcome
            };
            await this._unitOfWork.Matches.CreateAsync(match);
            return match;
        }

        [HttpGet]
        [Route("GetAllMatches")]
        public async Task<ActionResult<ICollection<Match>>> GetAllMatches(Guid leagueId)
        {
            var allMatches = await this._unitOfWork.Matches.FindAllAsync();
            if (allMatches.Any())
            {
                var filteredMatches = allMatches.Where(x => x.LeagueId == leagueId).ToList();
                return filteredMatches;
            }
            return NotFound();           
        }

        [HttpDelete]
        [Route("DeleteMatch")]
        public async Task<ActionResult<Match>> DeleteMatch(Guid matchId)
        {
            var Match = await this._unitOfWork.Matches.ReadAsync(matchId);
            if (Match != null)
            {
                await this._unitOfWork.Matches.DeleteAsync(Match.Id);
                return Match;
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateMatch")]
        public async Task<ActionResult<Match>> UpdateMatch(MatchViewModel match)
        {
            var Match = await this._unitOfWork.Matches.ReadAsync(match.Id);
            if (Match != null)
            {
                Match.LeagueId = match.LeagueId;
                Match.HomeTeamId = match.HomeTeamId;
                await this._unitOfWork.Matches.UpdateAsync(Match);
                return Match;
            }
            return NotFound();
        }
    }
}
