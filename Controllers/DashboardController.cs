using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Joe_s_Pizza.Models;
using Microsoft.EntityFrameworkCore;

namespace Joe_s_Pizza.Controllers
{
    public class DashboardController : Controller
    {

        private readonly PizzaDbContext _context;
        public DashboardController(PizzaDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _context.pizzas.ToListAsync());
        }

        // GET: DashboardController/Details/5
        public async Task<ActionResult> Details(int? pno)
        {
            if (pno == null)
            {
                return NotFound();
            }
            var pizza = await _context.pizzas.FirstOrDefaultAsync(x => x.Pno == pno);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }
    }
}