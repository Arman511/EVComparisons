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
        public async Task<IActionResult> Index(int? SortBy, int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            IQueryable<Cars> carsQuery = _context.Cars;

            switch (SortBy)
            {
                case 1:
                    carsQuery = carsQuery.OrderBy(m => m.Maker).ThenBy(m => m.Model);
                    break;
                case 2:
                    carsQuery = carsQuery.OrderBy(m => m.Model);
                    break;
                case 3:
                    carsQuery = carsQuery.OrderBy(m => m.FullPrice);
                    break;
                case 4:
                    carsQuery = carsQuery.OrderByDescending(m => m.FullPrice);
                    break;
                case 5:
                    carsQuery = carsQuery.OrderBy(m => m.NormalChargeTime);
                    break;
                default:
                    carsQuery = carsQuery.OrderBy(m => m.Maker).ThenBy(m => m.Model);
                    break;
            }

            var totalCount = await carsQuery.CountAsync();
            var carsList = await carsQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            ViewData["TotalCount"] = totalCount;
            ViewData["Page"] = pageNumber;

            return carsList != null
                ? View(carsList)
                : Problem("Entity set 'ApplicationDbContext.Cars' is null.");
        }


        public async Task<IActionResult> Search()
        {
            IQueryable<Cars> carsQuery = _context.Cars.OrderBy(c => c.Maker);
            var allMakers = await carsQuery.Select(m => m.Maker).Distinct().ToListAsync();
            ViewData["allMakers"] = allMakers;
            var allTypes = await carsQuery.Select(m => m.Type).Distinct().ToListAsync();
            ViewData["allTypes"] = allTypes;

            return _context.Cars != null
                ? View()
                : Problem("Entity set 'ApplicationDbContext.Cars' is null.");
        }


        public async Task<IActionResult> SearchResults(ExtraInfo.CarTypes? type,string? model = null, string ? maker = null, int minPrice=0, int maxPrice=10000000, int range=0, int chargeTime =0, int sortBy=0, int page = 1)
        {
            IQueryable<Cars> carsQuery = _context.Cars;

            // Apply filters based on search parameters
            if (!string.IsNullOrEmpty(maker))
            {
                carsQuery = carsQuery.Where(c => c.Maker != null && c.Maker.Equals(maker.Trim()));
                
            }
            if (type != null)
            {
                carsQuery = carsQuery.Where(c => c.Type.Equals(type));

            }
            if (!string.IsNullOrEmpty(model))
            {
                carsQuery = carsQuery.Where(c => c.Model != null && c.Model.Contains(model.Trim()));
            }
            carsQuery = carsQuery.Where(c => c.Range > range && c.FullPrice > minPrice && c.FullPrice < maxPrice);
            if (chargeTime != 0)
            {
                carsQuery = carsQuery.Where(c => c.NormalChargeTime < chargeTime);
            }

            // Apply sorting based on sortBy parameter
            switch (sortBy)
            {
                case 1:
                    carsQuery = carsQuery.OrderBy(m => m.Maker).ThenBy(m => m.Model);
                    break;
                case 2:
                    carsQuery = carsQuery.OrderBy(m => m.Model);
                    break;
                case 3:
                    carsQuery = carsQuery.OrderBy(m => m.FullPrice);
                    break;
                case 4:
                    carsQuery = carsQuery.OrderByDescending(m => m.FullPrice);
                    break;
                case 5:
                    carsQuery = carsQuery.OrderBy(m => m.NormalChargeTime);
                    break;
                default:
                    carsQuery = carsQuery.OrderBy(m => m.Maker).ThenBy(m => m.Model);
                    break;
            }

            // Perform pagination
            int pageSize = 10;
            int totalItems = await carsQuery.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            int currentPage = Math.Max(1, Math.Min(page, totalPages));

            // Retrieve the data for the current page
            var carsList = await carsQuery.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            // Pass the search parameters and pagination information to the view
            ViewData["maker"] = maker;
            ViewData["model"] = model;
            ViewData["range"] = range;
            ViewData["minPrice"] = minPrice;
            ViewData["maxPrice"] = maxPrice;
            ViewData["chargeTime"] = chargeTime;
            ViewData["type"] = type;
            ViewData["sortBy"] = sortBy;
            ViewData["Page"] = currentPage;
            ViewData["TotalCount"] = totalItems;

            return View("SearchResults", carsList);
        }




        public async Task<IActionResult> SelectCompare()
        {
            return _context.Cars != null ?
                        View(await _context.Cars.OrderBy(c => c.Maker).ThenBy(c => c.Model).ToListAsync()) :
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
