public static class OtpManager
{
    public static string GenerateOtp()
    {
        return new Random().Next(100000, 999999).ToString();
    }
}
