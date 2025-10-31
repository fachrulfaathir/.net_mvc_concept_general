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

        public IActionResult Index()
        {
            var item = _appContext.Items
                .Select(x => new Item
                {
                    Id = x.Id,
                    Name = x.Name ?? "(Tidak ada nama)",
                    Price = x.Price ?? 0,
                    Description = x.Description ?? "-"
                })
                .ToList();

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

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _appContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);

        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Name, Price, Description, Slug")] Item item)
        {

            if (ModelState.IsValid)
            {   
                _appContext.Update(item);
                await _appContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
