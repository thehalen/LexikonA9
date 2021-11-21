using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace LexiconA9.Controllers
{
    public class GuessingGame : Controller
    {
        public IActionResult Index()
        {
            ResetGame();
            ViewBag.Heading = "Guess-a-number";
            ViewBag.Guess = HttpContext.Session.GetInt32("guess");
            return View();
        }

        public void ResetGame()
        {
            HttpContext.Session.SetInt32("guess", new Random().Next(0, 100));
            HttpContext.Session.SetInt32("correct", new Random().Next(0, 100));
            HttpContext.Session.SetInt32("tries", 0);
        }

        [HttpPost]
        public IActionResult Index(string newGuess)
        {
            string s;
            ViewBag.Heading = "Guess-a-number";
            ViewBag.Guess = new Random().Next(0, 100);
            if (int.TryParse(newGuess, out int guess))
            {
                int corr = int.Parse(HttpContext.Session.GetInt32("correct").ToString());
                int tries = int.Parse(HttpContext.Session.GetInt32("tries").ToString()) + 1;
                HttpContext.Session.SetInt32("tries", tries);
                switch (guess-corr)
                {
                    case < 0:
                        s = "That's too low! Try again!";
                        break;
                    case 0:
                        ViewBag.Heading = "We have a winner!";
                        s = "Congratulations! You guessed the right number in " + tries + " tries";
                        ResetGame();
                        break;
                    case < 100:
                        s = "That's too high, try again!";
                        break;
                    default:
                        s = "Try an integer between 0 and 100!";
                        break;
                }
                if (guess>100) s = "That's waaay too high! Try a number between 0 and 100!";
                if (guess<0) s = "That's waaay too low! Try a number between 0 and 100!";
            }
            else
            {
                s = "Try an integer between 0 and 100!";
            }
            ViewBag.Message = s;
            return View();
        }

    }
}
