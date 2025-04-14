using catalogoZOO.Model;
using catalogoZOO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catalogoZOO.Controllers
{
    public class AnimalController : Controller
    {
        private readonly CatalogoZooContext _context;

        public AnimalController(CatalogoZooContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animals.OrderBy(a => a.Nome).ToListAsync());
        }
        /*
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Animals.OrderBy(a => a.Nome).ToListAsync());
            //return View(await _context.Animals.OrderBy(a => a.Nome).ToListAsync().ConfigureAwait(false));
            return View(await _context.Animals.OrderBy(a => a.Nome).ToListAsync().ConfigureAwait(false));
        }*/

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome", "Especie", "Habitat", "Genero", "Idade")] Animal animal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(animal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(animal);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId", "Nome", "Especie", "Habitat", "Genero", "Idade")] Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        public bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.AnimalId == id);
        }
    }
}
