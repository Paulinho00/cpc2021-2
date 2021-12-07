using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawełGryglewiczLab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawełGryglewiczLab5.Controllers
{
    public class DirectorsController : Controller
    {

        private readonly DatabaseContext _context;

        public DirectorsController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Directors.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var director = _context.Directors.Include(m => m.Movies).FirstOrDefault(m => m.Id.Equals(id));

            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        [HttpPost]
        public IActionResult Delete(Director director)
        {
            _context.Movies.RemoveRange(_context.Movies.Where(m => m.Director.Equals(director)));
            _context.Directors.Remove(director);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
