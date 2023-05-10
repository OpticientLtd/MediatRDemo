namespace MediatRDemo.Data;
using System.Threading.Tasks;

using MediatRDemo.Data.Repositories;

using Microsoft.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly MediatRDbContext _dbContext;
    private IEmployeeRepository _employees;
    private IDepartmentRepository _departments;

    public UnitOfWork(IDbContextFactory<MediatRDbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }
    public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_dbContext);

    public IDepartmentRepository Departments => _departments ??= new DepartmentRepository(_dbContext);

    public async Task<bool> CompleteAsync() => (await _dbContext.SaveChangesAsync()) > 0;

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
