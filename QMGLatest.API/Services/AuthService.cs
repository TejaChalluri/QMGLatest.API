using Microsoft.Win32;
using QMGLatest.API;
using System.Security.Cryptography;
using System.Text;
using static AuthController;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IOtpRepository _otpRepo;
    private readonly ITokenRepository _tokenRepo;
    private readonly IConfiguration _config;
    private readonly IEmailService _emailService;


    public AuthService(
        IUserRepository userRepo,
        IOtpRepository otpRepo,
        ITokenRepository tokenRepo,
        IConfiguration config,
        IEmailService emailService)
    {
        _userRepo = userRepo;
        _otpRepo = otpRepo;
        _tokenRepo = tokenRepo;
        _config = config;
        _emailService = emailService; 
    }



    //public string Login(LoginRequest request)
    //{
    //    try
    //    {
    //        var user = _userRepo.GetUser(request.UsernameOrEmail, request.Password);
    //        if (user == null)
    //            throw new Exception("Invalid credentials");

    //        var otp = OtpManager.GenerateOtp();

    //        _otpRepo.SaveOtp(new Otp
    //        {
    //            Username = request.UsernameOrEmail,
    //            UserId = user.UserId,
    //            OtpCode = otp,
    //            ExpiryTime = DateTime.Now.AddMinutes(5),
    //            IsUsed = false,
    //        });

    //        //  SEND OTP EMAIL ONLY IF EMAIL EXISTS
    //        if (!string.IsNullOrWhiteSpace(user.Email))
    //        {
    //            _emailService.SendOtpAsync(user.Email, otp);
    //        }

    //        return otp;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception($"Login failed: {ex.Message}");
    //    }
    //}


    public LoginResponse Login(LoginRequest request)
    {
        var user = _userRepo.GetUser(request.UsernameOrEmail, request.Password);

        if (user == null)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid username or password"
            };
        }

        var otp = OtpManager.GenerateOtp();

        _otpRepo.SaveOtp(new Otp
        {
            Username = request.UsernameOrEmail,
            UserId = user.UserId,
            OtpCode = otp,
            ExpiryTime = DateTime.Now.AddMinutes(5),
            IsUsed = false,
        });

        if (!string.IsNullOrWhiteSpace(user.Email))
        {
            _emailService.SendOtpAsync(user.Email, otp);
        }

        return new LoginResponse
        {
            Success = true,
            Message = "OTP sent successfully"
        };
    }

    public string VerifyOtp(OtpVerifyRequest request)
    {


        //    var otp = _otpRepo.GetOtp(request.UsernameOrEmail, request.Otp);
        //    if (otp == null)
        //        throw new Exception("Invalid OTP");

        //    var user = _userRepo.GetUser(request.UsernameOrEmail, request.Password);
        //    if (user == null)
        //        throw new Exception("User not found");

        //    var token = JwtTokenGenerator.GenerateToken(
        //        user,
        //        _config["JwtKey"]
        //    );

        //_tokenRepo.SaveToken(new Token
        //{
        //    Username = user.Username,
        //    JwtToken = token,
        //    RoleName = user.RoleName,
        //    RoleNumber = user.RoleNumber,
        //    ExpiryTime = DateTime.Now.AddMinutes(30)
        //});

        //    return token;



        var otp = _otpRepo.GetOtp(request.UsernameOrEmail, request.Otp);
        if (otp == null)
            return "error|Invalid OTP";

        var user = _userRepo.GetUser(request.UsernameOrEmail, request.Password);
        if (user == null)
            return "error|User not found";

        var token = JwtTokenGenerator.GenerateToken(
            user,
            _config["JwtKey"]
        );

        _tokenRepo.SaveToken(new Token
        {
            Username = user.Username,
            JwtToken = token,
            RoleName = user.RoleName,
            RoleNumber = user.RoleNumber,
            ExpiryTime = DateTime.Now.AddMinutes(30)
        });

        return token;
    }




}
