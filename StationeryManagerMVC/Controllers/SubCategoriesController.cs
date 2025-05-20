using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StationeryManager.Util;
using StationeryManagerApi;
using StationeryManagerLib.Dtos;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerMVC.Controllers
{
    public class SubCategoriesController : Controller
    {
        //private readonly StationeryDBContext _context;

        public SubCategoriesController(StationeryDBContext context)
        {
            //_context = context;
        }

        public IActionResult Index()
        {
            //var search = Request.Query["search"].ToString();
            //var query = _context.SubCategories.AsQueryable();
            //query = query.Where(x => x.IsDeleted != true);

            //if (!string.IsNullOrEmpty(search))
            //{
            //    query = query.Where(e => e.Name.Contains(search));
            //}

            //query = query.OrderByDescending(e => e.CreatedAt);

            //var subcategories = await query.ToListAsync();
            //var categoryIds = subcategories.Select(e => e.CategoryId).Distinct().ToList();
            //var categories = await _context.Categories.Where(e => categoryIds.Contains(e.Id.ToString())).ToListAsync();

            //var result = from subcategory in subcategories
            //                   join category in categories on subcategory.CategoryId equals category.Id.ToString()
            //                   select new SubCategoryDtoModel
            //                   {
            //                       Id = subcategory.Id,
            //                       Name = subcategory.Name,
            //                       Description = subcategory.Description,
            //                       CategoryName = category.Name,
            //                       CreatedAt = subcategory.CreatedAt,
            //                       UpdatedAt = subcategory.UpdatedAt
            //                   };
            //var categoryDtosList = result.ToList();
            //return View(categoryDtosList);
            return View();
        }

        public IActionResult Create()
        {
            //ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        public IActionResult Detail(string id)
        {
            //var subcategory = await _context.SubCategories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
            //if (subcategory == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories.Where(e => e.Id.ToString() == subcategory.CategoryId && e.IsDeleted != true).FirstOrDefaultAsync();
            //var subcategoryDto = new SubCategoryDtoModel
            //{
            //    Id = subcategory.Id,
            //    Name = subcategory.Name,
            //    Description = subcategory.Description,
            //    CategoryName = category?.Name,
            //    CreatedAt = subcategory.CreatedAt,
            //    UpdatedAt = subcategory.UpdatedAt
            //};
            //return View(subcategoryDto);
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(SubCategoryRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var subcategory = new SubCategoryModel
        //        {
        //            Name = request.Name,
        //            Description = request.Description,
        //            CategoryId = request.CategoryId,
        //            IsDeleted = false,

        //            CreatedAt = DateTime.Now,
        //            UpdatedAt = DateTime.Now,
        //        };

        //        await _context.SubCategories.AddAsync(subcategory);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        public IActionResult Edit(string id)
        {
            //var subcategory = await _context.SubCategories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
            //if (subcategory == null)
            //{
            //    return NotFound();
            //}

            //ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name", subcategory.CategoryId);
            //var request = new SubCategoryRequest
            //{
            //    Name = subcategory.Name,
            //    Description = subcategory.Description,
            //    CategoryId = subcategory.CategoryId
            //};
            //return View(request);
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, SubCategoryRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var subcategory = await _context.SubCategories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
        //        if (subcategory == null)
        //        {
        //            return NotFound();
        //        }
        //        subcategory.Name = request.Name;
        //        subcategory.Description = request.Description;
        //        subcategory.UpdatedAt = DateTime.Now;
        //        subcategory.CategoryId = request.CategoryId;

        //        _context.SubCategories.Update(subcategory);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var subcategory = await _context.SubCategories.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
        //    if (subcategory == null)
        //    {
        //        return NotFound();
        //    }
        //    subcategory.IsDeleted = true;
        //    subcategory.DeletedAt = DateTime.Now;

        //    _context.SubCategories.Update(subcategory);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
