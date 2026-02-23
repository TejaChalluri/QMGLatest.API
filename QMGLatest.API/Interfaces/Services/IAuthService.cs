using QMGLatest.API;
using static AuthController;

public interface IAuthService
{
    //string Login(LoginRequest request);
    LoginResponse Login(LoginRequest request);
    string VerifyOtp(OtpVerifyRequest request);

}
