using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            //1.
            ViewBag.Women = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();
            //2.
            ViewBag.Hockey = _context.Leagues
                .Where(l => l.Name.Contains("Hockey"))
                .ToList();
            //3.
            ViewBag.IsNotFootball = _context.Leagues
                .Where(l => l.Name.Contains("Football"))
                .ToList();
            //4.
            ViewBag.Conference = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            //5.
            ViewBag.Atlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            //6.
            ViewBag.Dallas = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();
            //7.
            ViewBag.Raptors = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();
            //8.
            ViewBag.City = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();
            //9.
            ViewBag.T = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();
            //10.
            ViewBag.Sorted = _context.Teams
                .OrderBy(l => l.TeamName)
                .ToList();
            //11.
            ViewBag.OrderedAlph = _context.Teams
                .OrderByDescending(t => t.TeamName)
                .ToList();
            //12.
            ViewBag.Cooper = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();
            //13.
            ViewBag.Joshua = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();
            //14.
            ViewBag.CooperExcept = _context.Players
                .Where(p => p.LastName.Contains("Cooper") && !p.FirstName.Contains("Joshua"))
                .ToList();
            //15.
            ViewBag.FirstNames = _context.Players
                .Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt"))
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            //1.
            ViewBag.TeamsInASC = _context.Teams
                .Include(t => t.CurrLeague)
                .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference")
                .ToList();
            //2.
            ViewBag.CurrPlayers = _context.Players
            .Include(p => p.CurrentTeam)
            .Where(p => p.CurrentTeam.TeamName == "Penguins")
            .ToList();
            //3.
            ViewBag.CurrIntPlayers = _context.Players
            .Include(p => p.CurrentTeam)
            .ThenInclude(t => t.CurrLeague)
            .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
            .ToList();
            //4.
            ViewBag.FootballLopez = _context.Players
            .Include(p => p.CurrentTeam)
            .ThenInclude(t => t.CurrLeague)
            .Where(p => p.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football")
            .Where(p => p.LastName == "Lopez")
            .ToList();
            //5.
            ViewBag.AllFootballPlayers = _context.Players
            .Include(p => p.CurrentTeam)
            .ThenInclude(t => t.CurrLeague)
            .Where(p => p.CurrentTeam.CurrLeague.Sport == "Football")
            .ToList();
            //6.
            ViewBag.Sophia = _context.Players
            .Include(p => p.CurrentTeam)
            .Where(p => p.FirstName == "Sophia")
            .ToList();
            //7.
            ViewBag.NotWashington = _context.Players
            .Include(p => p.CurrentTeam)
            .Where(p => p.LastName == "Flores")
            .Where(p => p.CurrentTeam.Location != "Washington")
            .Where(p => p.CurrentTeam.TeamName != "Roughriders")
            .ToList();
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}