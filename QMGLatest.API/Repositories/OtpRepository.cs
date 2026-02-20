using Microsoft.AspNetCore.Http.HttpResults;
using QMGLatest.API;
using QMGLatest.API;

public class OtpRepository : IOtpRepository
{
    private readonly ApplicationDbContext _context;

    public OtpRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SaveOtp(Otp otp)
    {
            _context.Otps.Add(otp);
            _context.SaveChanges();
        
    }
    

    public Otp GetOtp(string UsernameOrEmail, string otp)
    {
            return _context.Otps.FirstOrDefault(x =>
            x.Username == UsernameOrEmail &&
            x.OtpCode == otp &&
            x.ExpiryTime > DateTime.Now);
       
    }
}
