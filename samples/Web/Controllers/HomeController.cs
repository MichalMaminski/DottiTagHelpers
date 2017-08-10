using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Bogus;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ListDemo()
        {
            var dataGenerator = new Faker();

            var sampleList = new List<string>(10);

            for (int i = 0; i < sampleList.Capacity; i++)
            {
                sampleList.Add(dataGenerator.Name.FindName());
            }

            return View(sampleList);
        }
    }
}
