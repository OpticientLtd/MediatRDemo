namespace MediatRDemo.Data.Repositories;

using MediatRDemo.Data.Models;

using Opticient.EFCore.Repository.Interfaces;

public interface IDepartmentRepository : IRepository<Department, byte>
{
}
