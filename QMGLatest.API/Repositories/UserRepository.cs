using QMGLatest.API;
using QMGLatest.API;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }



    public User GetById(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.UserId == userId);
    }


    public User GetUser(string usernameOrEmail, string Password)
    {
        return _context.Users.FirstOrDefault(u =>
            (
                u.Username == usernameOrEmail || u.Email == usernameOrEmail) &&
                u.Password == Password
            );
    }

    public User GetByUsernameOrEmail(string usernameOrEmail)
    {
        return _context.Users.FirstOrDefault(u =>
            u.Username == usernameOrEmail ||
            u.Email == usernameOrEmail);
    }

    public void Register_User(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update_User(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Update_IsActive_Zero(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public User get_All_Users(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.UserId == userId);
    }


}
