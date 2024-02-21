using Microsoft.EntityFrameworkCore;

namespace Mission06___ChrisFowler.Models
{
    public class Context : DbContext // Bridge between database and application, allowing for CRUD functionality
    {
        public Context(DbContextOptions<Context> options) : base (options) // Constructor
        {

        }
        public DbSet<Application> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
