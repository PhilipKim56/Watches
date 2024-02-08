using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Watches.Models;

namespace Watches.Controllers
{
    public class WatchController : Controller
    {
        private readonly IWatchRepo _repo;
        public WatchController(IWatchRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var watch = _repo.GetWatches();
            return View(watch);
        }
        public IActionResult ViewWatch(int id)
        {
            var watch = _repo.GetWatchById(id);
            return View(watch);
        }
      

        public IActionResult UpdateWatch(int id)
        {
            watch prod = _repo.GetWatchById(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateWatchToDatabase(watch newwatch)
        {
            _repo.UpdateWatch(newwatch);

            return RedirectToAction("ViewWatch", new { id = newwatch.watch_id });

        }
        public IActionResult InsertWatch()
        {
            var prod = _repo.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertWatchToDatabase(watch watchToInsert)
        {
            _repo.InsertWatch(watchToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteWatch(watch watchToDelete)
        {
            _repo.DeleteWatch(watchToDelete);
            return RedirectToAction("Index");
        }
    }
}
