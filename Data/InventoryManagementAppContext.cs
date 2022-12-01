using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApp.Data
{
    public class InventoryManagementAppContext : DbContext
    {
        public InventoryManagementAppContext (DbContextOptions<InventoryManagementAppContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryManagementApp.Models.Computer> Computer { get; set; } = default!;
    }
}
