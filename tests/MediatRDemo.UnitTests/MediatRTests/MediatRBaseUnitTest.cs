namespace MediatRDemo.UnitTests.MediatRTests;

using MediatRDemo.API;
using MediatRDemo.Data;

using Microsoft.Extensions.DependencyInjection;

using NSubstitute;

public abstract class MediatRBaseUnitTest : BaseUnitTest
{
    public MediatRBaseUnitTest()
    {
        Services.AddAutoMapper(config => config.ConfigureMappings());
        Services.AddScoped(x => Substitute.For<IUnitOfWork>());
        Configure();
    }
    protected override void Configure()
    {
        base.Configure();
    }
}
