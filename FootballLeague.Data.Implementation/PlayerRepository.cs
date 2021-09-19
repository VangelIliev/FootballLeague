﻿using FootballLeague.Data.Entities;
using FootballLeague.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Implementation
{
    public class PlayerRepository : Repository<Player>,IPlayerRepository
    {
        public PlayerRepository(FootballLeagueDbContext dbContext) : base(dbContext)
        {

        }
    }
}
