namespace MediatRDemo.API.Models.Requests;

using System.ComponentModel.DataAnnotations;

public class EmployeeRequestModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public byte DepartmentId { get; set; }
    public int? ManagerId { get; set; }
    [Required]
    public int Salary { get; set; }
}
