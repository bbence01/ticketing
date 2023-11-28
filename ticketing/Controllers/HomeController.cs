using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Net.Sockets;
using ticketing.Models;

namespace ticketing.Controllers
{
   



    public class HomeController : Controller
    {
      

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger )
        {
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Ticket ticket)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/tickets", "tickets.txt");

            // Append text to the file
            System.IO.File.AppendAllText(path, ticket.Content + Environment.NewLine);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}