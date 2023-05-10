namespace MediatRDemo.Data.Repositories;

using MediatRDemo.Data.Models;

using Opticient.EFCore.Repository.Abstract;

public class DepartmentRepository : Repository<Department, byte>, IDepartmentRepository
{
    public DepartmentRepository(MediatRDbContext dbContext) : base(dbContext)
    {
    }
}
