using Challengify.Models;
using Challengify.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challengify.Controllers
{
    public class ChallengesController : Controller
    {
        private readonly Repository _repository;

        public ChallengesController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetChallenges());
        }

        [Route("challenge/{id}")]
        public IActionResult Challenge(string id) =>
            View("ViewItem", _repository.GetChallenges().First(x => x.Id == id));

        [HttpGet]
        public IActionResult New()
        {
            Challenge challenge = new Challenge();
            return View(challenge);
        }


    }
}
