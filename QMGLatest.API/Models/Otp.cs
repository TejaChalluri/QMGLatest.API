public class Otp
{
    public int OtpId { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public string OtpCode { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsUsed { get; set; }
}
