using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime.Intrinsics.Arm;

namespace EmptyProject2.Controllers
{
    public class GameController : Controller
    {
        //[ActionName("GuessingGame")]
        public IActionResult Index()
        {
            string? rndString = Request.Cookies["secretNumberC"];

            int secretNumber;
            if (rndString != null)
            {
                secretNumber = int.Parse(rndString);
            }
            else
            {
                secretNumber = CreateRdn(1, 100);
                CreateCookie(secretNumber);
            }

            ViewBag.SecretNumberVB = secretNumber;    

            return View();
        }

        [HttpPost]
        public IActionResult Index(int number, int secretNumber)
        {

            ViewBag.Message = CheckNumber(number, secretNumber);
            ViewBag.SecretNumberVB = secretNumber;

            return View();
        }

        public static string CheckNumber(int number, int secretNumber)
        {
           
            if (number <= 0)
                return "Please, enter a number greater than zero";

            if (number < secretNumber)
                return $"WRONG, The secret number is greater than {number}, Try again!";

            if (number > secretNumber)
                return $"WRONG, The secret number is less that {number}, Try again!";

            else
                return $"Congratulations, the secret number is {secretNumber}";
        }


        public void CreateCookie(int rdn)
        {
            CookieOptions options = new CookieOptions();
            //options.Expires = DateTimeOffset.UtcNow.AddMinutes(1);
            options.Expires = DateTimeOffset.UtcNow.AddDays(1);
            Response.Cookies.Append("secretNumberC", rdn.ToString(), options);
        }

        public int CreateRdn(int min, int max)        {
            
            Random random = new Random();
            int randomNumber = random.Next(min, max);
            return randomNumber;
        }

    }
}
