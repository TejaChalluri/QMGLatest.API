using QMGLatest.API;

public interface IOtpRepository
{
    void SaveOtp(Otp otp);
    Otp GetOtp(string UsernameOrEmail, string otp);
}
