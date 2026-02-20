using Microsoft.AspNetCore.Identity.Data;
using QMGLatest.API;

public interface IUserRepository
{
    User GetUser(string usernameOrEmail, string Password);
    public void Register_User(User user);
    public User GetByUsernameOrEmail(string usernameOrEmail);
    public User GetById(int userId);
    public void Update_User(User user);
    public void Update_IsActive_Zero(User user);
    public User get_All_Users(int userId);
}
