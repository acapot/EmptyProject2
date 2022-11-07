using Microsoft.AspNetCore.Mvc;

namespace EmptyProject2.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckFever()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CheckFever(double temperature)
        {
            ViewBag.Message = temperature switch
            {
                0 or <0 => "Please, enter temperature in degrees Celsius",
                < 30 => "Your temperature is not normal, it is too low",
                < 37 => "Your temperature is low",
                37 => "Your tempreture is normal",
                (> 37) and (<= 40) => "You have fever you should rest at home",
                > 40 => "Your temperature is very high you must go to the hospital"
            };
            return View();
        }
    }
}
