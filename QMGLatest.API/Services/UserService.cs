using Microsoft.Win32;
using QMGLatest.API;
using QMGLatest.API.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    
    public void Register_User(RegisterRequest user_register_request)
    {

            var existingUser = _userRepo.GetByUsernameOrEmail(user_register_request.Username);
            if (existingUser != null)
                throw new Exception("User already exists");

            var user = new User
            {
                Username = user_register_request.Username,
                Email = user_register_request.Email,
                Password = user_register_request.Password,
                RoleName = string.IsNullOrEmpty(user_register_request.RoleName) ? "Admin" : user_register_request.RoleName,
                RoleNumber = user_register_request.RoleNumber == 0 ? 1 : user_register_request.RoleNumber,
                IsActive = true
            };

            _userRepo.Register_User(user);
        
    }



    public void Update_User(int userId, UpdateUserRequest request)
    {

            var user = _userRepo.GetById(userId);
            if (user == null)
                throw new Exception("User not found");

            user.Username = request.Username;
            user.Email = request.Email;
            user.RoleName = string.IsNullOrEmpty(request.RoleName) ? user.RoleName : request.RoleName;
            user.RoleNumber = request.RoleNumber == 0 ? user.RoleNumber : request.RoleNumber;
            user.IsActive = request.IsActive;
            user.CreatedDate = DateTime.Now;

            _userRepo.Update_User(user);
        
    }




    public void Remove_User(int userId)
    {
            var user_data = _userRepo.GetById(userId);
            if (user_data == null)
                throw new Exception("User not found");
            user_data.IsActive = false;
            user_data.UpdatedDate = DateTime.Now;
            _userRepo.Update_IsActive_Zero(user_data);
    }


    public User get_All_Users(int userId)
    {
        var user = _userRepo.get_All_Users(userId);

        if (user == null)
            throw new Exception("User not found");

        return user;
    }




}
