using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Extentions;
using StationeryManagerApi.Service;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        private readonly IPasswordServices _passwordService;
        private readonly IAuthServices _authServices;

        public AuthController(IAccountServices accountServices, IPasswordServices passwordServices, IAuthServices authServices)
        {
            _accountServices = accountServices;
            _passwordService = passwordServices;
            _authServices = authServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            var account = await _accountServices.GetAccountByEmail(request.Email);
            if (account == null)
            {
                return NotFound($"Account with email {request.Email} not found");
            }

            if (account.IsDeleted)
            {
                return BadRequest($"Account with email {request.Email} is deleted");
            }

            var isValidPassword = _passwordService.VerifyPassword(account.PaswordHash, request.Password);
            if (!isValidPassword)
            {
                return Unauthorized("Invalid username or password");
            }



            var token = _authServices.GenerateJwtToken(account);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(token );
        }

        
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] UpdatePasswordRequest request)
        {

            var account = await _accountServices.GetAccountByEmail(request.Email);
            if (account == null)
            {
                return NotFound($"Account with email {request.Email} not found");
            }
            if (account.IsDeleted)
            {
                return BadRequest($"Account with email {request.Email} is deleted");
            }

            var result = await _accountServices.ResetPassword(account, request);
            return result > 0
                ? Ok("Password reset successfully")
                : BadRequest("Failed to reset password");
        }

    }
}
