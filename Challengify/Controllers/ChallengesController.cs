using Challengify.Data;
using Challengify.Models;
using Challengify.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challengify.Controllers
{
    public class ChallengesController : Controller
    {
        private readonly Repository _repository;
        ApplicationDbContext db = new ApplicationDbContext();

        public ChallengesController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Challenge> challenges = db.DbChallenges;
            return View(challenges);
        }

        [Route("challenge/{id}")]
        public IActionResult Challenge(string id) =>
            View("ViewItem", db.DbChallenges.First(x => x.Id == id));

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(string Name, string Desc, int Count)
        {
            Challenge challenge = new Challenge() { Name = Name, FullDescription = Desc, ShortDescription = Desc, Participants = new List<User>(), SumOfXP = 0, MaxParticipants = Count, Id = Guid.NewGuid().ToString(), Image = "IMG" };
            db.DbChallenges.Add(challenge);
            db.SaveChanges();
            return View("ViewItem", challenge);
        }

        [HttpPost]
        public IActionResult Join(string Id, string name)
        {
            Challenge challenge = db.DbChallenges.FirstOrDefault(x => x.Id == Id);
            if (challenge != null)
            {
                if (challenge.Participants == null)
                    challenge.Participants = new List<User>();
                var neededUser = db.DbUsers.First(x => x.UserName == name);
                challenge.Participants.Add(neededUser);
                db.SaveChanges();
            }
            return Redirect($"/challenge/{Id}");
        }

    }
}
