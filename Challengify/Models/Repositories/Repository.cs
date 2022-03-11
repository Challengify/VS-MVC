using System;
using System.Collections.Generic;
using System.Linq;
using Challengify.Data;

namespace Challengify.Models.Repositories
{
    public class Repository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) => _context = context;

        public IEnumerable<User> GetUsers() => _context.Users.OrderBy(x => x.Username);

        //public User GetUserById(Guid id) => _context.DbUsers.Single(x => x.Id == id);

        public IEnumerable<Challenge> GetChallenges() => _context.Challenges.OrderBy(x => x.Name);

        public Challenge GetChallengeById(string id) => _context.DbChallenges.Single(x => x.Id == id);
    }
}
