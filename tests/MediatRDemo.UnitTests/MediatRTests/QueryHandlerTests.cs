namespace MediatRDemo.UnitTests.MediatRTests;

using AutoMapper;

using FluentAssertions;

using MediatRDemo.API.MediatR.Handlers.QueryHandlers;
using MediatRDemo.API.MediatR.Requests.Queries;
using MediatRDemo.Data;
using MediatRDemo.Data.Models;

using Microsoft.Extensions.DependencyInjection;

using NSubstitute;

[TestClass]
public class QueryHandlerTests : MediatRBaseUnitTest
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private Department _department = new Department() { Id = 1, Name = "TestDepartment" };
    private Employee _employee = new Employee() { Id = 1, Name = "TestEmployee", DepartmentId = 1, Salary = 100 };

    public QueryHandlerTests()
    {
        _unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
        _mapper = base.ServiceProvider.GetRequiredService<IMapper>();
    }

    [TestMethod]
    public async Task GetDepartmentByIdQueryHandler_ShouldReturnData_WhenDataExists()
    {
        var handler = new GetDepartmentByIdQueryHandler(_unitOfWork, _mapper);
        _unitOfWork.Departments.GetAsync(default, default).ReturnsForAnyArgs(_department);
        var dto = await handler.Handle(new GetDepartmentByIdQuery(_department.Id), default);
        dto.Should().NotBeNull();
        dto.Id.Should().Be(_department.Id);
        dto.Name.Should().Be(_department.Name);
    }

    [TestMethod]
    public async Task GetDepartmentByIdQueryHandler_ShouldReturnNull_WhenDataDoesntExist()
    {
        var handler = new GetDepartmentByIdQueryHandler(_unitOfWork, _mapper);
        _unitOfWork.Departments.GetAsync(default, default).ReturnsForAnyArgs((Department)null);
        var dto = await handler.Handle(new GetDepartmentByIdQuery(_department.Id), default);
        dto.Should().BeNull();
    }

    [TestMethod]
    public async Task GetEmployeeByIdQueryHandler_ShouldReturnData_WhenDataExists()
    {
        var handler = new GetEmployeeByIdQueryHandler(_unitOfWork, _mapper);
        _unitOfWork.Employees.GetAsync(default, default).ReturnsForAnyArgs(_employee);
        var dto = await handler.Handle(new GetEmployeeByIdQuery(_employee.Id), default);
        dto.Should().NotBeNull();
        dto.Id.Should().Be(_employee.Id);
        dto.Name.Should().Be(_employee.Name);
    }

    [TestMethod]
    public async Task GetEmployeeByIdQueryHandler_ShouldReturnNull_WhenDataDoesntExist()
    {
        var handler = new GetEmployeeByIdQueryHandler(_unitOfWork, _mapper);
        _unitOfWork.Employees.GetAsync(default, default).ReturnsForAnyArgs((Employee)null);
        var dto = await handler.Handle(new GetEmployeeByIdQuery(_employee.Id), default);
        dto.Should().BeNull();
    }

    [TestMethod]
    public async Task GetAllDepartmentsQueryHandler_ShouldReturnData()
    {
        var handler = new GetAllDepartmentsQueryHandler(_unitOfWork, _mapper);
        _unitOfWork.Departments.GetAllAsync(default).ReturnsForAnyArgs(InitialData.InitialDepartments);
        var dtos = await handler.Handle(new GetAllDepartmentsQuery(), default);
        dtos.Should().HaveSameCount(InitialData.InitialDepartments);
    }

    [TestMethod]
    public async Task GetAllEmployeesQueryHandler_ShouldReturnData()
    {
        var handler = new GetAllEmployeesQueryHandler(_unitOfWork, _mapper);
        _unitOfWork.Employees.GetAllAsync(default).ReturnsForAnyArgs(InitialData.InitialEmployees);
        var dtos = await handler.Handle(new GetAllEmployeesQuery(), default);
        dtos.Should().HaveSameCount(InitialData.InitialEmployees);
    }
}