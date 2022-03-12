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

        public IEnumerable<User> GetUsers() => _context.DbUsers.OrderBy(x => x.UserName);

        public IEnumerable<Challenge> GetChallenges() => _context.Challenges.OrderBy(x => x.Name);

        public void AddChallenge(Challenge challenge) => _context.Challenges.Add(challenge);

    }
}
