using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LexiconA9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Test = "Welcome!";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.about1 = "Jag tycker att det är otroligt roligt att få chanser att utvecklas, och när det uppstått tillfällen med specialuppdrag (och nästan allt IT-relaterat) på min förra arbetsgivare så har jag många gånger fått förtroendet att lösa dem. Dessa är höjdpunkterna i mitt yrkesliv, så jag visste rätt tidigt att mjukvaruutveckling var dit jag ville komma.";
            ViewBag.about2 = "Under mina snart tolv år på samma företag så jobbade jag som gruppledare i Mölndal, och hade även omfattande kontakt med såväl kunder som andra avdelningar.Mitt största intresse och styrkeområde ligger dock inom datorer och IT.";
            ViewBag.about3 = "Så just detta är väl min främsta styrka jag tar med mig, att jag har jobbat med flera olika produktionssystem, kodat i flera språk och dessutom har en förmåga att kunna sätta se nya och alternativa lösningar.";
            ViewBag.about4 = "Jag har exempelvis gjort lösningar som samspelat med spårningsprogram, produktionssystem, planeringsverktyg, webbsidor med och utan API, skannrar, vågar och andra COM-anslutna enheter, instrumentstyrning, mätsystem m.m.";
            ViewBag.about5 = "På fritiden brukar jag förvilla mig i Wikipedia-djungeln, titta på dokumentärer, spela strategispel eller köra någon frågesport.";
            ViewBag.about6 = "Hoppas jag är lika intressant för er, som ni är för mig!";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Name = "Andreas Halen";
            ViewBag.Email = "halen (snabelaaa) alumni. chalmers punkt se";
            return View();
        }

        public IActionResult Projects()
        {
            string repos;
            HttpWebRequest request = WebRequest.Create("https://api.github.com/users/thehalen/repos") as HttpWebRequest;
            request.UserAgent = "TestApp";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                repos = reader.ReadToEnd();
            }
            //var res = repos.Split(','); snygga till det här så man inte dumpar en kubikmeter raw JSON på sidan
            ViewBag.Repos = repos;
            return View();
        }
    }
}
