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
    public class AccountsController : Controller
    {
        private readonly StationeryDBContext _context;
        private readonly PasswordHasher<object> _hasher = new();

        public AccountsController(StationeryDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var search = Request.Query["search"].ToString();
            var query = _context.Accounts.AsQueryable();
            query = query.Where(x => x.IsDeleted != true);
            
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Name.Contains(search));
            }

            query = query.OrderByDescending(e => e.CreatedAt);

            var accounts = query.ToList();

            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(string id)
        {
            var account = _context.Accounts.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountRequest request)
        {
            if (ModelState.IsValid)
            {
                var account = new AccountModel
                {
                    Name = request.Name,
                    Email = request.Email,
                    PaswordHash = HashPassword(request.Password),
                    Phone = request.Phone,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult Edit(string id)
        {
            var account = _context.Accounts.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
            if (account == null)
            {
                return NotFound();
            }
            var request = new UpdateAccountRequest
            {
                Name = account.Name,
                Email = account.Email,
                Phone = account.Phone,
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, UpdateAccountRequest request)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
                if (account == null)
                {
                    return NotFound();
                }
                account.Name = request.Name;
                account.Email = request.Email;
                account.Phone = request.Phone;
                account.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var account = _context.Accounts.FirstOrDefault(e => e.Id.ToString() == id && e.IsDeleted != true);
            if (account == null)
            {
                return NotFound();
            }
            account.IsDeleted = true;
            account.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        private string HashPassword(string password)
        {
            string hashPassword = _hasher.HashPassword(null, password);
            return hashPassword;
        }

        private bool VerifyPassword(string hashPassword, string password)
        {
            var result = _hasher.VerifyHashedPassword(null, hashPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
