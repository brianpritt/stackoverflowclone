using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StackOverflowClone.Models;
using StackOverflowClone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverflowClone.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Questions.Include(q => q.SubmittingUser).ToList());
        }

        public IActionResult Details(int id)
        {
            ViewBag.Question = _db.Questions.Include(q => q.SubmittingUser)
                .Include(q => q.Responses)
                .FirstOrDefault(q => q.Id == id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Details(Response response, int QuestionId)
        {
            response.Question = _db.Questions.FirstOrDefault(q => q.Id == QuestionId);
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            response.SubmittingUser = await _userManager.FindByIdAsync(userId);
            _db.Responses.Add(response);
            _db.SaveChanges();
            Debug.WriteLine("test");
            return RedirectToAction("Index");
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            question.SubmittingUser = await _userManager.FindByIdAsync(userId);
            _db.Questions.Add(question);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
