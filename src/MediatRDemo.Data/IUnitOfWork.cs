namespace MediatRDemo.Data;
using System.Threading.Tasks;

using MediatRDemo.Data.Repositories;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    IDepartmentRepository Departments { get; }
    Task<bool> CompleteAsync();
}
