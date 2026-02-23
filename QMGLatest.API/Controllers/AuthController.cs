using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using QMGLatest.API;
using System.Linq;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    //[HttpPost("login")]
    //public IActionResult Login(LoginRequest request)
    //{

    //        var otp = _authService.Login(request);
    //        return Ok(otp);

    //}


    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authService.Login(request);

        if (!result.Success)
            return BadRequest(new { message = result.Message });

        return Ok(new { message = result.Message });
    }



    [HttpPost("verify-otp")]
    public IActionResult VerifyOtp(OtpVerifyRequest request)
    {

        //var otp_v_request = _authService.VerifyOtp(request);
        //return Ok(new { token = otp_v_request });
        var result = _authService.VerifyOtp(request);

        if (result.Contains("|")) // Check if it's an error message
        {
            var errorMessage = result.Split('|')[1];
            return BadRequest(new { message = errorMessage });
        }

        return Ok(new { token = result });
    }

    [HttpGet("test-error")]
    public IActionResult TestError()
    {
        throw new Exception("This is a test error for NLog if didn't understood connect with Teja.");
    }

    

}

