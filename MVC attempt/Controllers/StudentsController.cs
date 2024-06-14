using Microsoft.AspNetCore.Mvc;
using MvcTraining.Data;
using MvcTraining.Models;
using MvcTraining.Models.Entities;

namespace MvcTraining.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student std)
        {
            _context.Students.Add(std);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
