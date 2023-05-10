namespace MediatRDemo.API;

using System.Reflection;

using MediatRDemo.Data;

using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        Configure(app);

        app.Run();

    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(MediatRDbContext));
        services.AddPooledDbContextFactory<MediatRDbContext>(options =>
        {
            options
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            if (string.IsNullOrEmpty(connectionString))
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
            else
            {
                options.UseSqlServer(connectionString);
            }
        });
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(config => config.ConfigureMappings());
    }

    private static void Configure(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetService<IDbContextFactory<MediatRDbContext>>().CreateDbContext();
        if (!dbContext.Database.IsInMemory() && dbContext.Database.IsRelational())
        {
            dbContext.Database.Migrate();
        }

        if (dbContext.Database.IsInMemory())
        {
            dbContext.Database.EnsureCreated();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
