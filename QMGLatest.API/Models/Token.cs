public class Token
{
    public int TokenId { get; set; }
    public string Username { get; set; }
    public string JwtToken { get; set; }
    public string RoleName { get; set; }
    public int RoleNumber { get; set; }
    public DateTime ExpiryTime { get; set; }
}

public class VerifyOtpResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
}