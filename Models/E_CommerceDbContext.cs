using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website_Project.Models;

public class E_CommerceDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var config = builder.Build();

        optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);

    }

    public DbSet<Category> categories { get; set; }
    public DbSet<Comment> comments { get; set; }
    public DbSet<Message> messages { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Setting> settings { get; set; }
    public DbSet<Status> statuses { get; set; }
    public DbSet<Supplier> suppliers { get; set; }
    public DbSet<User> users { get; set; }



}