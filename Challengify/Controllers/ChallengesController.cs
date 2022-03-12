using Challengify.Models;
using Challengify.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            IEnumerable<Challenge> challenges = _repository.GetChallenges();
            return View(challenges);
        }

        [Route("challenge/{id}")]
        public IActionResult Challenge(string id) =>
            View("ViewItem", _repository.GetChallenges().First(x => x.Id == id));

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(string Name, string Desc, int Count)
        {
            Challenge challenge = new Challenge() { Name = Name, FullDescription = Desc, ShortDescription = Desc, Participants = new List<User>(), SumOfXP = 0, MaxParticipants = Count, Id = "123", Image = "IMG" };
            _repository.AddChallenge(challenge);
            return View("ViewItem", _repository.GetChallenges().First(x => x.Id == challenge.Id));
        }


    }
}
