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

        public HomeController(ILogger<HomeController> logger, IGuestbookEntryDao guestbookEntryDao)
        {
            _logger = logger;
            _guestbookEntryDao = guestbookEntryDao;
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
            var indexViewModel = new IndexViewModel
            {
                entries = entryList,
                currentPage = page,
                pageCount = (int)Math.Ceiling((double)_guestbookEntryDao.CountEntries() / postsPerPage)
            };
            return View(indexViewModel);
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
            if (IsValidEntry(entry))
            {
                _guestbookEntryDao.AddEntry(entry);
            }

            return RedirectToAction("Index", "Home", new { page = 0 });
        }

        private bool IsValidEntry(GuestbookEntry entry)
        {
            if (entry.Name == null)
            {
                return false;
            }
            else if (entry.Name.Length < 1 | entry.Name.Length > 30)
            {
                return false;
            }
            if (entry.Comment == null)
            {
                return false;
            }
            else if (entry.Comment.Length < 1 | entry.Comment.Length > 120)
            {
                return false;
            }
            if (entry.Email == null)
            {
                return false;
            }
            else if (entry.Email.Length < 3 || !entry.Email.Contains('@'))
            {
                return false;
            }
            if (entry.Timestamp > DateTime.Now)
            {
                return false;
            }

            return true;
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
