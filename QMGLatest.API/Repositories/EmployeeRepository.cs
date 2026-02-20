using Microsoft.AspNetCore.Http.HttpResults;
using QMGLatest.API;
using QMGLatest.API;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Employee> Get_All_The_Employees()
    {
            return _context.Employees.Where(e => e.IsActive == true).ToList();
    }
}
