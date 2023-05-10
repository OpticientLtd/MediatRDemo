namespace MediatRDemo.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Opticient.EFCore.Repository.Abstract;

[Table("Employee")]
public class Employee : DbIdEntity<int>
{

    [Required]
    [StringLength(25)]
    public string Name { get; set; } = default!;

    [Required]
    public byte DepartmentId { get; set; }

    public int? ManagerId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    [InverseProperty(nameof(Data.Models.Department.Employees))]
    public Department Department { get; set; } = default!;

    [ForeignKey(nameof(ManagerId))]
    [InverseProperty(nameof(Employee.ManagedEmployees))]
    public Employee Manager { get; set; }

    public int Salary { get; set; }

    [InverseProperty(nameof(Employee.Manager))]
    public ICollection<Employee> ManagedEmployees { get; set; } = new List<Employee>();
}
