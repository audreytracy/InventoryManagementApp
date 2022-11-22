using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagementApp.Models;

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
