using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appDimak.Models;

namespace appDimak.Views.Orders
{
    public class IndexModel : PageModel
    {
        private readonly appDimak.Models.NorthwindContext _context;

        public IndexModel(appDimak.Models.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).ToListAsync();
            }
        }
    }
}
