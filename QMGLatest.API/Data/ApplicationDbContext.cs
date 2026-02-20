using Microsoft.EntityFrameworkCore;
using QMGLatest.API;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Otp> Otps { get; set; }
    public DbSet<Token> Tokens { get; set; }
}
