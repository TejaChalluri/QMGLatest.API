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

        var result = _authService.VerifyOtp(request);

        if (result.Contains("|"))
        {
            var errorMessage = result.Split('|')[1];
            return BadRequest(new { message = errorMessage });
        }

        return Ok(new { token = result });
    }
   

}

