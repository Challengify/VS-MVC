using System;
using System.Linq;
using Challengify.Data;

namespace Challengify.Models.Repositories
{
    public class Repository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) => _context = context;

        public IQueryable<User> GetUsers() => _context.DbUsers.OrderBy(x => x.Username);

        public User GetUserById(string id) => _context.DbUsers.Single(x => x.Id == id);

        public IQueryable<Challenge> GetChallenges() => _context.DbChallenges.OrderBy(x => x.Name);

        public Challenge GetChallengeById(string id) => _context.DbChallenges.Single(x => x.Id == id);
    }
}
