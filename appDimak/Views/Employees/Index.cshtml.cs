using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appDimak.Models;

namespace appDimak.Views.Employees
{
    public class IndexModel : PageModel
    {
        private readonly appDimak.Models.NorthwindContext _context;

        public IndexModel(appDimak.Models.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees
                .Include(e => e.ReportsToNavigation).ToListAsync();
            }
        }
    }
}
