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
    public class SportRepository : Repository<Sport>, ISportRepository
    {

        public SportRepository(HattrickApplicationContext context) : base(context)
        {
        }

        public Sport UpdateSport(Sport sport)
        {

            if (sport != null)
            {
                HattrickApplicationContext.Entry(sport).State = EntityState.Modified;
            }
            return sport;
        }


        public HattrickApplicationContext HattrickApplicationContext
        {
            get { return Context as HattrickApplicationContext; }
        }
    }
}
