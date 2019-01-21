using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal.Repositories
{
    public interface ISportRepository : IRepository<Sport>
    {
        Sport UpdateSport(Sport sport);
    }
}
