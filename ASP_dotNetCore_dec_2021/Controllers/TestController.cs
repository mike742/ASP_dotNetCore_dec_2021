using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Controllers
{
    public class TestController : Controller
    {
        public string Index()
        {
            return "Hello World!";
        }

        public IActionResult redirect()
        {
            return Redirect("https://google.com");
        }

        public IActionResult jsonResult()
        {
            return Json(
                new
                {
                    message = "this is a json result",
                    date = DateTime.Now
                }
                );
        }

        public IActionResult contentResult()
        {
            return Content("This is a content");
        }
    }
}
