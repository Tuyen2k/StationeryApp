using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Extentions;
using StationeryManagerApi.Service;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    //
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        private readonly IPasswordServices _passwordServices;

        public AccountController(IAccountServices accountServices, IPasswordServices passwordServices) {
            _accountServices = accountServices;
            _passwordServices = passwordServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterModel filter) {
            var list = await _accountServices.GetAllAccounts(filter);
            return Ok(list);
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAll([FromQuery] FilterModel filter)
        {
            var count = await _accountServices.CountAll(filter);
            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            
            var account = await _accountServices.GetAccountById(id);
            if (account == null)
            {
                return NotFound($"Account with {id} not found");
            }
            return Ok(account);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] UpdateAccountRequest request) {
            
            var claim = HttpContext.User.ToClaimModel();
            var account = await _accountServices.GetAccountById(id);
            if (account == null)
            {
                return NotFound($"Account with id {id} not found");
            }

            var existingAccount = await _accountServices.GetAccountByEmail(request.Email);
            if (existingAccount != null && existingAccount.Id != account.Id)
            {
                return BadRequest($"Email {request.Email} already exists");
            }

            var result = await _accountServices.UpdateAccount(account, request, claim);

            if(result == 0)
            {
                return BadRequest($"Update failed");
            }
            return Ok("Update success");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            var claim = HttpContext.User.ToClaimModel();
            var existingAccount = await _accountServices.GetAccountByEmail(request.Email);
            if (existingAccount != null)
            {
                return BadRequest($"Email {request.Email} already exists");
            }

            var result = await _accountServices.CreateAccount(request, claim);
            if (result == null) {
                return BadRequest();
            }
            return Ok("Create success");
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id) {
            var claim = HttpContext.User.ToClaimModel();
            var account = await _accountServices.GetAccountById(id);
            if (account == null) {
                return NotFound($"Account with id {id} not found");
            }

            var result = await _accountServices.DeleteAccount(account, claim);

            if (result == 0)
            {
                return BadRequest($"Delete failed");
            }
            return Ok("Delete success");

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CheckPassword(string id,[FromBody]string password) {
            var account = await _accountServices.GetAccountById(id);
            if (account == null) {
                return NotFound($"Account with id {id} not found");
            }
            var verify = _passwordServices.VerifyPassword(account.PaswordHash, password);
            return Ok($"verify -------- {verify}");
        }

    }
}
