namespace MediatRDemo.Data;

using MediatRDemo.Data.Models;

using Microsoft.EntityFrameworkCore;

public class MediatRDbContext : DbContext
{
    public MediatRDbContext(DbContextOptions<MediatRDbContext> options) : base(options)
    {

    }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasData(InitialData.InitialDepartments);
        modelBuilder.Entity<Department>().Property(d => d.Name)
            .IsUnicode(false);
        modelBuilder.Entity<Department>().HasIndex(d => d.Name, "UIX_Department_Name").IsUnique();

        modelBuilder.Entity<Employee>().Property(d => d.Name)
            .IsUnicode(false);

        modelBuilder.Entity<Employee>().HasData(InitialData.InitialEmployees);
    }
}
