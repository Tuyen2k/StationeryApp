using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationeryManager.Util;
using StationeryManagerApi;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerMVC.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly StationeryDBContext _context;

        public CategoriesController(StationeryDBContext context)
        {
            //_context = context;
        }

        public IActionResult Index()
        {
            //var search = Request.Query["search"].ToString();
            //var query = _context.Categories.AsQueryable();
            //query = query.Where(x => x.IsDeleted != true);

            //if (!string.IsNullOrEmpty(search))
            //{
            //    query = query.Where(e => e.Name.Contains(search));
            //}

            //query = query.OrderByDescending(e => e.CreatedAt);

            //var categories = await query.ToListAsync();

            //return View(categories);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(string id)
        {
            //var category = await _context.Categories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
            //if (category == null)
            //{
            //    return NotFound();
            //}
            //return View(category);
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CategoryRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var category = new CategoryModel
        //        {
        //            Name = request.Name,
        //            Description = request.Description,
        //            IsDeleted = false,
        //            CreatedAt = DateTime.Now,
        //            UpdatedAt = DateTime.Now,
        //        };

        //        await _context.Categories.AddAsync(category);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        public IActionResult Edit(string id)
        {
            //var category = await _context.Categories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
            //if (category == null)
            //{
            //    return NotFound();
            //}
            //var request = new CategoryRequest
            //{
            //    Name = category.Name,
            //    Description = category.Description,
            //};
            //return View(request);
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, CategoryRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var category = await _context.Categories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }
        //        category.Name = request.Name;
        //        category.Description = request.Description;
        //        category.UpdatedAt = DateTime.Now;

        //        _context.Categories.Update(category);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var category = await _context.Categories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    category.IsDeleted = true;
        //    category.DeletedAt = DateTime.Now;

        //    _context.Categories.Update(category);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
