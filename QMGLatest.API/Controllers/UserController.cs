using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QMGLatest.API.Interfaces;

namespace QMGLatest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;

        public UserController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }


        //[HttpPost("register")]
        //public IActionResult Register_User([FromBody] RegisterRequest user_register_request)
        //{
        //        _userService.Register_User(user_register_request);
        //        return Ok(user_register_request);
        //}

        [HttpPost("register")]
        public IActionResult Register_User([FromBody] RegisterRequest user_register_request)
        {
            
                _userService.Register_User(user_register_request);
                if (user_register_request != null)
            {
                return Ok(new
                {
                    success = true,
                    message = "Registration successful!"
                });
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    message = "Registration faile!"
                });
            }
        }


        [HttpPost("Update_User/{userId}")]
        public IActionResult Update_User(int userId, [FromBody] UpdateUserRequest request)
        {
                _userService.Update_User(userId, request);
                return Ok(new { Message = "User updated successfully" });
        }

        [Authorize]
        [HttpPost("Remove_User/{userId}")]
        public IActionResult Remove_User(int userId)
        {
            var user = _userService.get_All_Users(userId);

            if (user.RoleName != "Admin")
            {
                return StatusCode(403, new
                {
                    Message = "Only admin users can delete users"
                });
            }

            _userService.Remove_User(userId);
            return Ok(new { Message = "User deleted successfully" });
        }

    }
}

