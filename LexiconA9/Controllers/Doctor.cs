using LexiconA9.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9.Controllers
{
    public class Doctor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FeverCheck()
        {
            ViewBag.Message = "Please enter a temperature";
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(string temp, string scale)
        {
            if (!double.TryParse(temp, out double tempr)) return RedirectToAction("FeverCheck");
            Temperature tm = new Temperature(tempr, scale);
            ViewBag.Message = tm.Fever();
            return View();
        }
    }
}
