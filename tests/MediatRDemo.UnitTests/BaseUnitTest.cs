namespace MediatRDemo.UnitTests;
using System;

using Microsoft.Extensions.DependencyInjection;

public abstract class BaseUnitTest
{
    protected IServiceProvider ServiceProvider { get; private set; }
    protected IServiceCollection Services { get; private set; } = new ServiceCollection();

    protected virtual void Configure()
    {
        ServiceProvider = Services.BuildServiceProvider();
    }
}
