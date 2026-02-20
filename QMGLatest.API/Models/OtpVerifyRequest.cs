public class OtpVerifyRequest
{

    
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
    public string Otp { get; set; }
}

public class AuthResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
}
