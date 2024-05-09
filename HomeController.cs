using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TemperatureConverter.Models;

namespace TemperatureConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult ConvertTemperature(ValueClass model)
        {
            if (ModelState.IsValid)
            {
                if (model.FromUnit == "Celsius" && model.ToUnit == "Fahrenheit")
                {
                    model.ConvertedTemperature = Math.Round((model.Temperature * 9 / 5) + 32,2);
                }
                else if (model.FromUnit == "Fahrenheit" && model.ToUnit == "Celsius")
                {
                    model.ConvertedTemperature = Math.Round((model.Temperature - 32) * 5 / 9,2);
                }

            else if (model.FromUnit == "Celsius" && model.ToUnit == "Kelvin")
                {
                    model.ConvertedTemperature = Math.Round(model.Temperature + 273.15, 2); // Rounded to 2 decimal places
                }
                else if (model.FromUnit == "Kelvin" && model.ToUnit == "Celsius")
                {
                    model.ConvertedTemperature = Math.Round(model.Temperature - 273.15, 2); // Rounded to 2 decimal places
                }
                else if (model.FromUnit == "Fahrenheit" && model.ToUnit == "Kelvin")
                {
                    model.ConvertedTemperature = Math.Round((model.Temperature - 32) * 5 / 9 + 273.15,2);
                }
                else if (model.FromUnit == "Kelvin" && model.ToUnit == "Fahrenheit")
                {
                    model.ConvertedTemperature = Math.Round((model.Temperature * 9/5)+32 , 2); // Rounded to 2 decimal places
                }

                // Return the same view with the updated model
                return View("Index", model);
            }
            // If model state is not valid, return the view with validation errors
            return View("Index", model);
        }
    }
}