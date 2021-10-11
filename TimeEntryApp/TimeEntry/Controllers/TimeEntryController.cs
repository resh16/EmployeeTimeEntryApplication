using BusinessLogic;
using BusinessObjectLayer.Models;
using BusinessObjectLayer.ViewModel;
using DataAccessLayer;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _db;

        public TimeEntryController(EntryBL entryBL, AccountBL accountBL, UserManager<ApplicationUser> userManager, AppDbContext db)
        {
            _entryBL = entryBL;
            _accountBL = accountBL;
            _userManager = userManager;
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            List<BusinessObjectLayer.Models.TimeEntry> entries = new List<BusinessObjectLayer.Models.TimeEntry>();

            ApplicationUser user;

            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (id != null)
            {
                user = await this._userManager.FindByIdAsync(id);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    entries = _entryBL.GetId(user);
                }
            }

            return View(entries);
        }

        public IActionResult CreateEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(BusinessObjectLayer.Models.TimeEntry entry)
        {

            ApplicationUser user;

            var particularUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (particularUserId != null)
            {
                user = await this._userManager.FindByIdAsync(particularUserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _entryBL.CreateEntry(user, entry);
                }
            }

            return View(entry);
        }


        [HttpGet]
        public IActionResult BreakIndex()
        {
            IEnumerable<Break> breakList = _db.Breaks;

            return View(breakList);
        }

        public IActionResult AddBreak()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBreak(int id, Break @break)
        {
            ApplicationUser user;

            var particularUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (particularUserId != null)
            {
                user = await this._userManager.FindByIdAsync(particularUserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _entryBL.CreateBreak(user, id, @break);
                }
            }

            return View(@break);
        }

        public async Task<IActionResult> DeleteEntry(int? id)
        {
            ApplicationUser user;

            var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (UserId != null)
            {
                user = await this._userManager.FindByIdAsync(UserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _entryBL.DeleteEntry(user, id);
                }
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteBreak(int? id)
        {
            ApplicationUser user;

            var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (UserId != null)
            {
                user = await this._userManager.FindByIdAsync(UserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _entryBL.DeleteBreak(user, id);
                }
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> EmployeeDashboard(DateTime monthValue, TotalBreak breaks)
        {
            List<BusinessObjectLayer.Models.TimeEntry> entry = new();

            ApplicationUser user;

            var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;



            if (UserId != null)
            {
                user = await _userManager.FindByIdAsync(UserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    entry = _entryBL.GetMonth(user, monthValue);
                }
            }

            return View(entry);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AdminDashboard(BusinessObjectLayer.Models.TimeEntry entry)
        {
            List<BusinessObjectLayer.Models.TimeEntry> entries = new List<BusinessObjectLayer.Models.TimeEntry>();

            ApplicationUser user;

            ViewBag.UserId = entry.Id;

            if (entry != null)
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    entries = _entryBL.GetEntry();
                }
            }

            return View(entries);
        }
    }
}