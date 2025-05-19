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
        private readonly StationeryDBContext _context;

        public SubCategoriesController(StationeryDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var search = Request.Query["search"].ToString();
            var query = _context.SubCategories.AsQueryable();
            query = query.Where(x => x.IsDeleted != true);
            
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Name.Contains(search));
            }

            query = query.OrderByDescending(e => e.CreatedAt);

            var subcategories = query.ToList();
            var categoryIds = subcategories.Select(e => e.CategoryId).Distinct().ToList();
            var categories = _context.Categories.Where(e => categoryIds.Contains(e.Id.ToString())).ToList();

            var result = from subcategory in subcategories
                               join category in categories on subcategory.CategoryId equals category.Id.ToString()
                               select new SubCategoryDtoModel
                               {
                                   Id = subcategory.Id,
                                   Name = subcategory.Name,
                                   Description = subcategory.Description,
                                   CategoryName = category.Name,
                                   CreatedAt = subcategory.CreatedAt,
                                   UpdatedAt = subcategory.UpdatedAt
                               };
            var categoryDtosList = result.ToList();
            return View(categoryDtosList);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var subcategory = _context.SubCategories.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
            if (subcategory == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.Where(e => e.Id.ToString() == subcategory.CategoryId && e.IsDeleted != true).FirstOrDefaultAsync();
            var subcategoryDto = new SubCategoryDtoModel
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                Description = subcategory.Description,
                CategoryName = category?.Name,
                CreatedAt = subcategory.CreatedAt,
                UpdatedAt = subcategory.UpdatedAt
            };
            return View(subcategoryDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var subcategory = new SubCategoryModel
                {
                    Name = request.Name,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    IsDeleted = false,

                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _context.SubCategories.Add(subcategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult Edit(string id)
        {
            var subcategory = _context.SubCategories.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
            if (subcategory == null)
            {
                return NotFound();
            }

            ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name", subcategory.CategoryId);
            var request = new SubCategoryRequest
            {
                Name = subcategory.Name,
                Description = subcategory.Description,
                CategoryId = subcategory.CategoryId
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, SubCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var subcategory = _context.SubCategories.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
                if (subcategory == null)
                {
                    return NotFound();
                }
                subcategory.Name = request.Name;
                subcategory.Description = request.Description;
                subcategory.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var subcategory = _context.SubCategories.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
            if (subcategory == null)
            {
                return NotFound();
            }
            subcategory.IsDeleted = true;
            subcategory.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
