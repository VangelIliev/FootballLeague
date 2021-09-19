using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Entities
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
