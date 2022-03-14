using Challengify.Data;
using Challengify.Models;
using Challengify.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challengify.Controllers
{
    public class UsersController : Controller
    {
        private readonly Repository _repository;
        ApplicationDbContext db = new ApplicationDbContext();

        public UsersController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.DbUsers);
        }

        [Route("users/{Username}")]
        public new IActionResult Profile(string Username) =>
            View("ViewItem", db.DbUsers.First(x => x.Email == Username));

    }
}
