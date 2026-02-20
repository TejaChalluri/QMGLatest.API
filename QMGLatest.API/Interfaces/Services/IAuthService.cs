using QMGLatest.API;

public interface IAuthService
{
    string Login(LoginRequest request);
    string VerifyOtp(OtpVerifyRequest request);

}
