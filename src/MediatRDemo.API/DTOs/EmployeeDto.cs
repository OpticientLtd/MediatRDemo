namespace MediatRDemo.API.DTOs;
public class EmployeeDto
{

    public int Id { get; set; }
    public string Name { get; set; }
    public byte DepartmentId { get; set; }
    public int? ManagerId { get; set; }
    public int Salary { get; set; }

}
