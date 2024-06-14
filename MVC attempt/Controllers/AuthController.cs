using Microsoft.AspNetCore.Mvc;
using MvcTraining.Data;
using MvcTraining.Models.Entities;

namespace MvcTraining.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            var usr = _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User usr)
        {
            var user = _context.Users.FirstOrDefault(u=> u.Email == usr.Email && u.Password == usr.Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
