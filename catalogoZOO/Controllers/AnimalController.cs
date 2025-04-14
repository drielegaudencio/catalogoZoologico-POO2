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
        /*private static List<Animal> animais = new List<Animal>()
        {
            new Animal() {
                AnimalId = 1,
                Nome = "Cleo",
                Especie = "Felino",
                Habitat = "florestas tropicais",
                Genero = "Female",
                Idade = 5
            }
        };*/

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
                    return RedirectToAction(nameof(IndexAsync));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(animal);
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Animals.OrderBy(a => a.Nome).ToListAsync());
        }
        public bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.AnimalId == id);
        }
    }
}
