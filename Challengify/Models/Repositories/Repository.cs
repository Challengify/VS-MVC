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

        public User GetUserById(Guid id) => _context.DbUsers.Single(x => x.Id == id);
    }
}
