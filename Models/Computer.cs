using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public int ManufacturerSerialNumber { get; set; }
        public string? OfficeRoomNumber { get; set; }
        public string? OfficeLocation { get; set; }
        public string? ComputerSpecification { get; set; }
        public string? OperatingSystem { get; set; }
        public string? OwnerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }
        public decimal Price { get; set; }

    }
}
