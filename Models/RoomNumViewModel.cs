using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Models
{
    public class RoomNumViewModel
    {
        public List<Computer>? Computers { get; set; }
        public SelectList? RoomNums { get; set; }
        public string? ComputerRoomNumber { get; set; }
        public string? SearchString { get; set; }
    }
}
