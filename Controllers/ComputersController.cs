using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagementApp.Data;
using InventoryManagementApp.Models;

namespace InventoryManagementApp.Controllers
{
    public class ComputersController : Controller
    {
        private readonly InventoryManagementAppContext _context;

        public ComputersController(InventoryManagementAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Computers
        [HttpGet]
        public async Task<IActionResult> Index(string searchInstallationDateBeginning, string searchInstallationDateEnding,
            string computerRoomNumber, string searchSerialNumber, string searchPriceBeginning, string searchPriceEnding)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> roomNumQuery = from c in _context.Computer orderby c.OfficeRoomNumber select c.OfficeRoomNumber;
            
            var computers = from m in _context.Computer select m;
            // search by installation date
            if (!String.IsNullOrEmpty(searchInstallationDateBeginning) && !String.IsNullOrEmpty(searchInstallationDateEnding))
                computers = computers.Where(s => s.InstallationDate! >= DateTime.Parse(searchInstallationDateBeginning) && 
                s.InstallationDate! <= DateTime.Parse(searchInstallationDateEnding));
            // search by price (does nothing if text inputs not valid prices)
            if (!String.IsNullOrEmpty(searchPriceBeginning) && !String.IsNullOrEmpty(searchPriceEnding))
                if (decimal.TryParse(searchPriceBeginning, out decimal priceBeg) && decimal.TryParse(searchPriceEnding, out decimal priceEnd))
                    computers = computers.Where(s => s.Price! >= priceBeg && s.Price! <= priceEnd);
            // search by serial number
            if (!String.IsNullOrEmpty(searchSerialNumber))
                computers = computers.Where(s => s.ManufacturerSerialNumber.ToString()!.Contains(searchSerialNumber));
            //search by room number
            if (!String.IsNullOrEmpty(computerRoomNumber))
                computers = computers.Where(x => x.OfficeRoomNumber == computerRoomNumber);

            var roomNumVM = new RoomNumViewModel {
                RoomNums = new SelectList(await roomNumQuery.Distinct().ToListAsync()),
                Computers = await computers.ToListAsync()
            };

            return View(roomNumVM);

        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufacturerSerialNumber,OfficeRoomNumber,OfficeLocation,ComputerSpecification,OperatingSystem,OwnerName,InstallationDate,Price")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerSerialNumber,OfficeRoomNumber,OfficeLocation,ComputerSpecification,OperatingSystem,OwnerName,InstallationDate,Price")] Computer computer)
        {
            if (id != computer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Computer == null)
            {
                return Problem("Entity set 'InventoryManagementAppContext.Computer'  is null.");
            }
            var computer = await _context.Computer.FindAsync(id);
            if (computer != null)
            {
                _context.Computer.Remove(computer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
          return _context.Computer.Any(e => e.Id == id);
        }
    }
}
