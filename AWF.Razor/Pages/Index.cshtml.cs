using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AWF.Razor.Data;
using AWF.Razor.Models.Domain;

namespace AWF.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AWF.Razor.Data.AuditDbContext _context;

        public IndexModel(AWF.Razor.Data.AuditDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
