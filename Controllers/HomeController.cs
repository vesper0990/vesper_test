using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vesper_test.Models;
using MySql.Data.MySqlClient;

namespace vesper_test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("wiadomosc");
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

	[HttpGet("Check")]
	public IActionResult Check(){
		string result = "true";
		try{
			var conn = new MySqlConnection("Server=db;Database=Students;Uid=user_name_1;Pwd=my-secret-pw");
			conn.Open();
			conn.Close();
		}catch(Exception e){
			Console.WriteLine("Message: " + e.Message);
			Console.WriteLine("Stack: " + e.StackTrace);
			result = "false";
		}
		return Content(result);
	}
    }
}
