namespace MediatRDemo.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Opticient.EFCore.Repository.Abstract;

[Table("Department")]
public class Department : DbIdEntity<byte>
{

    [Required]
    [StringLength(25)]
    public string Name { get; set; } = default!;

    [InverseProperty(nameof(Employee.Department))]
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}