using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopBrandsContext _context;

        public LaptopController(LaptopBrandsContext context)
        {
            _context = context;
        }

        // GET: Laptop
        public async Task<IActionResult> Index()
        {
              return _context.Laptops != null ? 
                          View(await _context.Laptops.ToListAsync()) :
                          Problem("Entity set 'LaptopBrandsContext.Laptops'  is null.");
        }

        // GET: Laptop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptop/Create
        public IActionResult Create()
        {
            return View();
        }

        /*--------------------------*/

        // POST: Laptop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Price,Year")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

          //  CreateLaptopViewModel viewModel = new CreateLaptopViewModel(laptop);
            return View(new CreateLaptopViewModel(laptop));
        }




        //public IActionResult CreateLaptop()
        //{
        //    return View(new CreateLaptop());
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateLaptop formResult)
        //{
        //    if (!string.IsNullOrWhiteSpace(formResult.ModelName) && !string.IsNullOrWhiteSpace(formResult.Brand)
        //        && formResult.Price > 0 && formResult.Year > 0)
        //    {
        //        Laptop newLaptop = new Laptop(
        //            formResult.ModelName,
        //            _context.Brands.FirstOrDefault(b => b.Name == formResult.Brand),
        //            formResult.Price,
        //            formResult.Year;

        //        formResult.Result = newLaptop;
        //        _context.Add(newLaptop);
        //    }
        //    return View(formResult);
        //}


        /*--------------------------*/

        // GET: Laptop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // POST: Laptop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Price,Year")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
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
            return View(laptop);
        }

        // GET: Laptop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laptops == null)
            {
                return Problem("Entity set 'LaptopBrandsContext.Laptops'  is null.");
            }
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptops.Remove(laptop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
          return (_context.Laptops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
