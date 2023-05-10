namespace MediatRDemo.API.Models.Requests;

using System.ComponentModel.DataAnnotations;

public class DepartmentRequestModel
{
    [Required]
    public string Name { get; set; }
}
