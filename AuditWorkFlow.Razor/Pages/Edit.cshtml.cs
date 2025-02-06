using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuditWorkFlow.Razor.Data;
using AuditWorkFlow.Razor.Models.Domain;
using AuditWorkFlow.Razor.Repositories.Abstractions;
using AutoMapper;
using AuditWorkFlow.Razor.Models.Dtos;

namespace AuditWorkFlow.Razor.Pages
{
    public class EditModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public EditModel(ICustomerRepository _customerRepository, IMapper _mapper)
        {
            customerRepository = _customerRepository;
            mapper = _mapper;
        }

        [BindProperty]
        public CustomerDto CustomerDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await customerRepository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            CustomerDto = mapper.Map<CustomerDto>(customer);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
