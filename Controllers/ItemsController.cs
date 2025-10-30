using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testing_general.Data;
using Testing_general.Models;

namespace Testing_general.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _appContext;

        public ItemsController(MyAppContext appContext)
        { _appContext = appContext; }

        public async Task<IActionResult> Index()
        {
            var item = await _appContext.Items.ToListAsync();

            return View(item);
        }
        public IActionResult Overview()
        {
            var item = new Item()
            {
                Name = "Keyboard"
            };
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, Description, Slug")] Item item)
        {
            if (ModelState.IsValid)
            {

                _appContext.Items.Add(item);
                await _appContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            return Content("id " + id);
        }
    }
}
