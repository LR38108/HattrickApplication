using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Dal.Repositories;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {

        public TeamRepository(HattrickApplicationContext context) : base(context)
        {
        }

        public Team UpdateTeam(Team team)
        {

            if (team != null)
            {
                HattrickApplicationContext.Entry(team).State = EntityState.Modified;
            }
            return team;
        }



        public HattrickApplicationContext HattrickApplicationContext
        {
            get { return Context as HattrickApplicationContext; }
        }
    }
}
