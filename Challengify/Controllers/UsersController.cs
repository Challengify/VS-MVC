using Challengify.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challengify.Controllers
{
    public class UsersController : Controller
    {
        private readonly Repository _repository;

        public UsersController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetUsers());
        }

        [Route("users/{Username}")]
        public new IActionResult User(string Username) =>
            View("ViewItem", _repository.GetUsers().First(x => x.Email == Username));
    }
}
