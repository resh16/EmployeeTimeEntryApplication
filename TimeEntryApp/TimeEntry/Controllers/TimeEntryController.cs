using BusinessLogic;
using BusinessObjectLayer.Models;
using BusinessObjectLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Entry.Controllers
{
    public class TimeEntryController : Controller
    {
        private readonly EntryBL _entryBL;
        private readonly AccountBL _accountBL;

        public TimeEntryController(EntryBL entryBL, AccountBL accountBL)
        {
            _entryBL = entryBL;
            _accountBL = accountBL;
        }

        [Authorize]
        public IActionResult Index()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return View();
        }

        public IActionResult CreateEntry()
        {
            EntryView_Model entry = new EntryView_Model();
            entry.BreakList.Add(new Break() { TimeEntryId = 1 });
            return View(entry);
        }

        [HttpPost]
        public IActionResult CreateEntry(EntryView_Model model)
        {
            var breakList = model.BreakList;

            _entryBL.SetBreak(breakList);

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            BusinessObjectLayer.Models.TimeEntry entry = new BusinessObjectLayer.Models.TimeEntry
            {
                Date = model.Date,
                InTime = model.InTime,
                OutTime = model.OutTime,
            };

            _entryBL.SetEntry(entry);

            return View("Index");
        }

        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
