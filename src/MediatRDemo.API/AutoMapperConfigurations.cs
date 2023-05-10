namespace MediatRDemo.API;

using AutoMapper;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.Models.Requests;
using MediatRDemo.Data.Models;

public static class AutoMapperConfigurations
{
    public static void ConfigureMappings(this IMapperConfigurationExpression configuration)
    {
        configuration.CreateMap<Employee, EmployeeDto>();
        configuration.CreateMap<EmployeeRequestModel, Employee>(MemberList.Source);

        configuration.CreateMap<Department, DepartmentDto>();
        configuration.CreateMap<DepartmentRequestModel, Department>(MemberList.Source);
    }
}
