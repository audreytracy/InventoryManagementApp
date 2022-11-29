using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagementApp.Data;
using System;
using System.Linq;


namespace InventoryManagementApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InventoryManagementAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<InventoryManagementAppContext>>()))
            {
                // Look for any movies.
                if (context.Computer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Computer.AddRange(
                    new Computer
                    {
                        ManufacturerSerialNumber = 123456,
                        OfficeRoomNumber = "120",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "macOS",
                        OwnerName = "Bob Johnson",
                        InstallationDate = DateTime.Parse("2015-3-13"),
                        Price = 400M
                    },

                    new Computer
                    {
                        ManufacturerSerialNumber = 113456,
                        OfficeRoomNumber = "121",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "macOS",
                        OwnerName = "Bob Johnson",
                        InstallationDate = DateTime.Parse("2016-3-13"),
                        Price = 400M
                    },

                    new Computer
                    {
                        ManufacturerSerialNumber = 111456,
                        OfficeRoomNumber = "121",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "macOS",
                        OwnerName = "Bob Johnson",
                        InstallationDate = DateTime.Parse("2016-3-13"),
                        Price = 400M
                    },

                    new Computer
                    {
                        ManufacturerSerialNumber = 111156,
                        OfficeRoomNumber = "121",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "macOS",
                        OwnerName = "Quincy Fiddlesworth",
                        InstallationDate = DateTime.Parse("2016-3-13"),
                        Price = 400M
                    },
                    new Computer
                    {
                        ManufacturerSerialNumber = 111116,
                        OfficeRoomNumber = "123",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "La",
                        OperatingSystem = "Linux",
                        OwnerName = "George W. Bush",
                        InstallationDate = DateTime.Parse("2016-3-13"),
                        Price = 400M
                    },
                    new Computer
                    {
                        ManufacturerSerialNumber = 111111,
                        OfficeRoomNumber = "123",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "macOS",
                        OwnerName = "Trisha Peytas",
                        InstallationDate = DateTime.Parse("2010-3-13"),
                        Price = 400M
                    },
                    new Computer
                    {
                        ManufacturerSerialNumber = 122222,
                        OfficeRoomNumber = "123",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "Windows",
                        OwnerName = "Gertrude Francin",
                        InstallationDate = DateTime.Parse("2010-3-13"),
                        Price = 400M
                    },
                    new Computer
                    {
                        ManufacturerSerialNumber = 122226,
                        OfficeRoomNumber = "123",
                        OfficeLocation = "Sugihara Hall",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "Unix",
                        OwnerName = "Shaniqua Sugihara",
                        InstallationDate = DateTime.Parse("2010-3-13"),
                        Price = 400M
                    },
                    new Computer
                    {
                        ManufacturerSerialNumber = 122256,
                        OfficeRoomNumber = "124",
                        OfficeLocation = "QBB",
                        ComputerSpecification = "Desktop",
                        OperatingSystem = "Windows",
                        OwnerName = "Phillipe O'Malley",
                        InstallationDate = DateTime.Parse("2010-3-13"),
                        Price = 400M
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
