using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/employees")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService service)
    {
        _employeeService = service;
    }

    [HttpGet("Get_All_The_Employees")]
    public IActionResult Get_All_The_Employees()
    {

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(role))
                return Unauthorized("Role not found in token");
                return Ok(_employeeService.Get_All_The_Employees(role));
       


    }

   
}
