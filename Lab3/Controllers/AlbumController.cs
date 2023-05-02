using Lab3.Data;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class AlbumController : Controller
    {
        List<Album> _albums;

        public AlbumController(IAlbumList albums)
        {
            _albums = albums.GetAlbums();
        }

        public IActionResult Index()
        {
            return View(_albums);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Album a)
        {
            if (!ModelState.IsValid)
            {
                return View(a);
            }
            a.Id = _albums.Count();
            _albums.Add(a);
            return RedirectToAction("Details", new {id = a.Id });
        }
        public IActionResult Details(int id)
        {
            Album a = _albums.FirstOrDefault(a => a.Id == id);
            if(a == null)
            {
                return NotFound();
            }
            return View(a);
        }
    }
}
