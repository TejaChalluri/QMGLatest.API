namespace QMGLatest.API.Interfaces
{
    public interface IUserService
    {
        public void Register_User(RegisterRequest user_register_request);
        public void Update_User(int userId, UpdateUserRequest request);
        public void Remove_User(int userId);
        public User get_All_Users(int userId);


    }
}
