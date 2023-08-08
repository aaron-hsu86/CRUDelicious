#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace _3_CRUDelicious.Models;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Dish> Dishes { get; set; } 
}
