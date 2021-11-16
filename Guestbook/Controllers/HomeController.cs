using Guestbook.Models;
using Guestbook.ViewModels;
using GuestbookData.DAL;
using GuestbookData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Guestbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGuestbookEntryDao _guestbookEntryDao;
        private const int postsPerPage = 5;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _guestbookEntryDao = new GuestbookEntryDao();
        }

        public IActionResult Index(int page = 0)
        {
            var entryList = new List<Entry>();
            var rawEntries = _guestbookEntryDao.GetEntries(page * postsPerPage, postsPerPage);
            foreach (var rawEntry in rawEntries)
            {
                var entry = new Entry
                {
                    Name = rawEntry.Name,
                    Email = rawEntry.Email,
                    Comment = rawEntry.Comment
                };
                entryList.Add(entry);
            }
            return View(entryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GuestbookEntry entry)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            entry.Timestamp = DateTime.Now;
            _guestbookEntryDao.AddEntry(entry);

            return RedirectToAction("Index", "Home", new { page = 0 });
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
