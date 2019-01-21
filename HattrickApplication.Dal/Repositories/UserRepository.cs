using HattrickApplication.Dal.Repositories;
using HattrickApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HattrickApplication.Dal
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(HattrickApplicationContext context) : base(context)
        {
        }



        public decimal CreditBalance(int id, decimal balance)
        {
            User user = HattrickApplicationContext.Users.Find(id);
            if (user == null)
            {
                return 0;
            }
            else
            {
                user.Balance += balance;
                HattrickApplicationContext.SaveChanges();
                return user.Balance;

            }
        }

        public User UpdateUser(User user)
        {
            if (user != null)
            {
                HattrickApplicationContext.Entry(user).State = EntityState.Modified;
                HattrickApplicationContext.SaveChanges();
            }
            return user;
        }

        public HattrickApplicationContext HattrickApplicationContext
        {
            get { return Context as HattrickApplicationContext; }
        }
    }
}
