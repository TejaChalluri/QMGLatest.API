using QMGLatest.API;

public interface IEmployeeService
{
    public List<EmployeeResponseDto> Get_All_The_Employees(string role);
}
