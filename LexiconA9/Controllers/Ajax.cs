using LexiconA9.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9.Controllers
{
    public class Ajax : Controller
    {
        public IActionResult Index()
        {
            if (PeopleViewModel.PersonsListView.Count < 1)
            {
                PeopleViewModel.MakePeople();
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            List<PersonModel> personModel = PeopleViewModel.listOfPeople;
            return PartialView("_persons", personModel);
        }

        [HttpPost]
        public IActionResult GetPersonByID(int PersonID)
        {
            List<PersonModel> personModel = PeopleViewModel.GetPersonByID(PersonID);
            return PartialView("_persons", personModel);
        }

        [HttpPost]
        public IActionResult DeletePersonById(int PersonID)
        {            
            PeopleViewModel.DeletePerson(PersonID);
            return RedirectToAction("Index");
        }

    }
}
