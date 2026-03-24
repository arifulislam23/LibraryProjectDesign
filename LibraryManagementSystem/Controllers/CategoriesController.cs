using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }


        public IActionResult List()
        {
            var dataList = _context.Categories.ToList();

            return View(dataList);
        }

        public IActionResult DetailsView(int id)
        {
            var data = _context.Categories.Where(x => x.CategoryId == id)
                .FirstOrDefault();

            if (data == null)
                return NotFound();

            return View(data);
        }


        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {
            var checkdata = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            if (checkdata == null)
                return Json(new { success = false, msg = "Category not Found!" });


            _context.Categories.Remove(checkdata);
            _context.SaveChanges();

            return Json(new { success = true, msg = "Category Deleted" });

        }




















        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category =  _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

    
        public IActionResult Create()
        {
            var datalist = _context.Categories
                .OrderByDescending(x=>x.CreateAt)
                .Take(5)
                .ToList();

            ViewBag.RecentCategories = datalist;

            ViewBag.RecentlyAdded = "Recently Added come from controller";


            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Name,Description,IsActive,CreateAt,UpdateAt")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        [HttpGet]
        public IActionResult EditCategories(int id)
        {
            if(id <=0 )
            {
                return NotFound();
            }

            var dataset = _context.Categories
                .Where(x => x.CategoryId == id).FirstOrDefault();
            //select * from Categories where CategoryId = id

            if (dataset == null)
                return NotFound();

            return View(dataset);
        }

        [HttpPost]
        public IActionResult EditCategories(Category userinput)
        {
            if (userinput == null)
                return View(userinput);

            if (userinput.CategoryId <= 0)
                return NotFound();


            var oldData = _context.Categories
                .Where(x => x.CategoryId == userinput.CategoryId).FirstOrDefault();

            if(oldData == null)
                return NotFound();


            oldData.Name = userinput.Name;
            oldData.Description = userinput.Description;
            oldData.IsActive = userinput.IsActive;
            oldData.UpdateAt = DateTime.Now;


            _context.Update(oldData);
            _context.SaveChanges();


            return RedirectToAction(nameof(List));
        }







        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name,Description,IsActive,CreateAt,UpdateAt")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpGet, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
