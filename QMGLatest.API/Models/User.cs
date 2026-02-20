public class User
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RoleName { get; set; }
    public int RoleNumber { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get;  set; }
}


public class RegisterRequest
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RoleName { get; set; }
    public int RoleNumber { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateUserRequest
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
    public int RoleNumber { get; set; }
    public bool IsActive { get; set; }
    public DateTime? UpdatedDate { get;set; }
}
