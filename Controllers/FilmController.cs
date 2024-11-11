using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film3.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film() {Id = 1 , Name = "Film1", Description = "Opis1", Price = 4},
            new Film() {Id = 2 , Name = "Film2", Description = "Opis2", Price = 5},
            new Film() {Id = 3 , Name = "Film3", Description = "Opis3", Price = 3},
            new Film() {Id = 4 , Name = "Film4", Description = "Opis4", Price = 4}
        };
        
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
            
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film updatedFilm)
        {
            var film = films.FirstOrDefault(x => x.Id == id);

            film.Name = updatedFilm.Name;
            film.Description = updatedFilm.Description;
            film.Price = updatedFilm.Price;

            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film film)
        {
            film = films.FirstOrDefault(x => x.Id == id);
            films.Remove(film);
            int newId = 1;
            foreach (var f in films)
            {
                f.Id = newId++;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
