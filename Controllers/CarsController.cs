using EVComparisons.Data;
using EVComparisons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVComparisons.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return _context.Cars != null ?
                        View(await _context.Cars.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
        }

        public async Task<IActionResult> Search()
        {
            return _context.Cars != null ?
                        View("Search") :
                        Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
        }

        public async Task<IActionResult> SearchResults(string maker, int minPrice, int maxPrice, int range, int chargeTime)
        {
            if (maker == null)
            {
                return _context.Cars != null ?
               View("Index", await _context.Cars.Where(c => c.Range > range && c.FullPrice > minPrice && c.FullPrice < maxPrice && c.NormalChargeTime < chargeTime).ToListAsync()) :
               Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
            }
            return _context.Cars != null ?
               View("Index", await _context.Cars.Where(c => c.Maker.Equals(maker.Trim()) && c.Range >range && c.FullPrice > minPrice && c.FullPrice <maxPrice).ToListAsync()) :
               Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
        }
        

        public async Task<IActionResult> SelectCompare()
        {
            return _context.Cars != null ?
                        View(await _context.Cars.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
        }

        public async Task<IActionResult> ShowCompareResult(int Car1, int Car2, int Car3)
        {
            List<int> carIds = new List<int>();

            if (Car1 != -1)
            {
                carIds.Add(Car1);
            }
            if (Car2 != -1)
            {
                carIds.Add(Car2);
            }
            if (Car3 != -1)
            {
                carIds.Add(Car3);
            }
            if (_context.Cars != null)
            {
                var carsToDisplay = await _context.Cars.Where(c => carIds.Contains(c.Id)).ToListAsync();
                return View("ShowCompareResult", carsToDisplay);
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.Cars' is null.");
            }
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string password, [Bind("Id,Type,ImageLink,Maker,Model,Range,FullPrice,Seats,Made,CargoVolume,RoofRails,TowHitch,TowWeight,MaxPayload,Safety,BatteryCapacity,NormalChargePower,NormalChargeTime,NormalChargePort,NormalPortLocation,FastChargePower,FastChargeTime,FastChargePort,FastPortLocation,TopSpeed,NaughtTo60,Efficiency,TotalPower,TotalTorque,Drive,Length,Width,Height,Link")] Cars cars)
        {
            if (ModelState.IsValid && password == "JeffIsRight")
            {
                _context.Add(cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }


        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string password, int id, [Bind("Id,Type,ImageLink,Maker,Model,Range,FullPrice,Seats,Made,CargoVolume,RoofRails,TowHitch,TowWeight,MaxPayload,Safety,BatteryCapacity,NormalChargePower,NormalChargeTime,NormalChargePort,NormalPortLocation,FastChargePower,FastChargeTime,FastChargePort,FastPortLocation,TopSpeed,NaughtTo60,Efficiency,TotalPower,TotalTorque,Drive,Length,Width,Height,Link")] Cars cars)
        {
            if (id != cars.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && password == "JeffIsRight")
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsExists(cars.Id))
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
            return View(cars);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string password)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
            }
            var cars = await _context.Cars.FindAsync(id);
            if (cars != null && password == "JeffIsRight")
            {
                _context.Cars.Remove(cars);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
