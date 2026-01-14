using Microsoft.AspNetCore.Mvc;
using FDMC.Data;
using FDMC.Models;

namespace FDMC.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cats = _context.Cats.ToList();
            return View(cats);
        }

        // GET: Cats/Details/5
        public IActionResult Details(int id)
        {
            var cat = _context.Cats.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        [HttpPost]
        public IActionResult Create(Cat cat)
        {
            if (!ModelState.IsValid)
            {
                return View(cat);
            }

            _context.Cats.Add(cat);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Cats/Edit/5
        public IActionResult Edit(int id)
        {
            var cat = _context.Cats.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Cat updatedCat)
        {
            if (id != updatedCat.Id || !ModelState.IsValid)
            {
                return View(updatedCat);
            }
            var cat = _context.Cats.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            cat.Name = updatedCat.Name;
            cat.Age = updatedCat.Age;
            cat.Breed = updatedCat.Breed;
            cat.ImageUrl = updatedCat.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
