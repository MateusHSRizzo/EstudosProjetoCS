﻿using EstudoProjetoCS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstudoProjetoCS.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HomeModel home = new HomeModel();

            home.Nome = "Mateus Rizzo";
            home.Email = "mateusrizzo@yahoo.com";

            return View(home);
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