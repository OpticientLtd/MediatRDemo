namespace MediatRDemo.Data.Repositories;

using MediatRDemo.Data.Models;

using Opticient.EFCore.Repository.Abstract;

public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
{
    public EmployeeRepository(MediatRDbContext dbContext) : base(dbContext)
    {
    }
}
