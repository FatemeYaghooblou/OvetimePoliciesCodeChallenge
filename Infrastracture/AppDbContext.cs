using Core.Entities.EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("connection string");
        }
    }
    public DbSet<Employee> Employees { get; set; }
}