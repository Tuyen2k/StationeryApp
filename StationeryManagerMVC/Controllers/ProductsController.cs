using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StationeryManagerApi;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerMVC.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly StationeryDBContext _context;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(StationeryDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            //_context = context;
            //_webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            //var search = Request.Query["search"].ToString();

            //var query = _context.Products.AsQueryable();
            //query = query.Where(x => x.IsDeleted != true);

            //if (!string.IsNullOrEmpty(search))
            //{
            //    query = query.Where(e => e.Name.Contains(search));
            //}

            //query = query.OrderByDescending(e => e.CreatedAt);

            //var products = await query.ToListAsync();
            //var categoryIds = subcategories.Select(e => e.CategoryId).Distinct().ToList();
            //var categories = _context.Categories.Where(e => categoryIds.Contains(e.Id.ToString())).ToList();

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
            //return View(products);
            return View();
        }

        public IActionResult Create()
        {
            //ViewBag.SubCategoryList = new SelectList(_context.SubCategories, "Id", "Name");
            return View();
        }

        public IActionResult Detail(string id)
        {
            //var product = await _context.Products.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //var subCategory = await _context.Categories.Where(e => e.Id.ToString() == product.SubCategoryId && e.IsDeleted != true).FirstOrDefaultAsync();
            //var subcategoryDto = new SubCategoryDtoModel
            //{
            //    Id = subcategory.Id,
            //    Name = subcategory.Name,
            //    Description = subcategory.Description,
            //    CategoryName = category?.Name,
            //    CreatedAt = subcategory.CreatedAt,
            //    UpdatedAt = subcategory.UpdatedAt
            //};
            //return View(product);
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(IFormFile ImageFile, ProductRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // start upload image
        //        if (ImageFile != null && ImageFile.Length > 0)
        //        {
        //            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "upload/images");
        //            Directory.CreateDirectory(uploadsFolder); // đảm bảo thư mục tồn tại

        //            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await ImageFile.CopyToAsync(fileStream);
        //            }

        //            request.ImageUrl = uniqueFileName; // chỉ lưu tên file
        //        }
        //        // end

        //        var sku = await GenerateSku();
        //        var product = new ProductModel
        //        {
        //            Name = request.Name,
        //            Description = request.Description,
        //            ImageUrl = request.ImageUrl,
        //            SubCategoryId = request.SubCategoryId,
        //            Price = request.Price,
        //            PriceSale = request.PriceSale,
        //            Sku = sku,

        //            IsDeleted = false,
        //            CreatedAt = DateTime.Now,
        //            UpdatedAt = DateTime.Now,
        //        };

        //        await _context.Products.AddAsync(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        public IActionResult Edit(string id)
        {
            //var product =  await _context.Products.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //ViewBag.SubCategoryList = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            //var request = new ProductRequest
            //{
            //    Name = product.Name,
            //    Description = product.Description,
            //    SubCategoryId = product.SubCategoryId,
            //    Sku = product.Sku,
            //    ImageUrl = product.ImageUrl,
            //    Price = product.Price,
            //    PriceSale = product.PriceSale
            //};
            //return View(request);
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, ProductRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product = await _context.Products.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }
        //        product.Name = request.Name;
        //        product.Description = request.Description;
        //        product.ImageUrl = request.ImageUrl;
        //        product.SubCategoryId = request.SubCategoryId;
        //        product.Price = request.Price;
        //        product.PriceSale = request.PriceSale;
        //        product.UpdatedAt = DateTime.Now;

        //        if (!string.IsNullOrEmpty(request.Sku) && request.Sku != product.Sku)
        //        {
        //            product.Sku = request.Sku;
        //        }

        //        _context.Products.Update(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var product = await _context.Products.Where(e => e.Id.ToString() == id && e.IsDeleted != true).FirstOrDefaultAsync();
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    product.IsDeleted = true;
        //    product.DeletedAt = DateTime.Now;

        //    _context.Products.Update(product);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //private async Task<string> GenerateSku()
        //{
        //    var fromDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);
        //    var sku = $"SKU-{fromDate.ToString("yyyyMMdd")}";
        //    var countInDate = await _context.Products
        //                        .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= fromDate.AddDays(1))
        //                        .CountAsync();

        //    var countNumber = (countInDate + 1).ToString("D6");
        //    sku += $"-{countNumber}";

        //    return sku;
        //}
    }
}
