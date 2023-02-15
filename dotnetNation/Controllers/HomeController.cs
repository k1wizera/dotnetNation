using dotnetNation.Data;
using dotnetNation.Data.Repository;
using dotnetNation.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetNation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController(IRepository repo) 
        { 
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }
    }
}
