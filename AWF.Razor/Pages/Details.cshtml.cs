using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AWF.Razor.Data;
using AWF.Razor.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using static AWF.Razor.Models.Enums.Common;

namespace AWF.Razor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AWF.Razor.Data.AuditDbContext _context;

        public DetailsModel(AWF.Razor.Data.AuditDbContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;
        
        

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
