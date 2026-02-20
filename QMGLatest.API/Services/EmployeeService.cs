using QMGLatest.API;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<EmployeeResponseDto> Get_All_The_Employees(string role) 
    { var employees = _employeeRepository.Get_All_The_Employees();
        if (role == "Admin") 
        { 
            return employees.Select(e => new EmployeeResponseDto
            { 
                EmployeeId = e.EmployeeId, 
                Name = e.Name, 
                Email = e.Email,
                Department = e.Department, 
                Designation = e.Designation 
            }).ToList();
        } if (role == "User")
        { 
            return employees.Select(e => new EmployeeResponseDto
            { 
                EmployeeId = null, 
                Name = e.Name, 
                Email = "", 
                Department = e.Department, 
                Designation = ""
            }).ToList(); 
        } 
        throw new Exception("Unauthorized role"); 
    }
}
