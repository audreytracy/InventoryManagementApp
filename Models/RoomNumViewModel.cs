using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InventoryManagementApp.Models
{
    public class RoomNumViewModel
    {
        public List<Computer>? Computers { get; set; }
        public SelectList? RoomNums { get; set; }
        public string? ComputerRoom { get; set; }
        public string? SearchString { get; set; }
    }
}
