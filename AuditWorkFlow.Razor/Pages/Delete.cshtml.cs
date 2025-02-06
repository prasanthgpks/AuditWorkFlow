using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuditWorkFlow.Razor.Data;
using AuditWorkFlow.Razor.Models.Domain;
using AuditWorkFlow.Razor.Repositories.Abstractions;
using AutoMapper;
using AuditWorkFlow.Razor.Repositories;
using AuditWorkFlow.Razor.Models.Dtos;

namespace AuditWorkFlow.Razor.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public DeleteModel(ICustomerRepository _customerRepository, IMapper _mapper)
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
            else
            {
                CustomerDto = mapper.Map<CustomerDto>(customer);
                
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await customerRepository.GetByIdAsync(id.Value);
            CustomerDto = mapper.Map<CustomerDto>(customer);
            if (customer != null)
            {
                await customerRepository.DeleteAsync(id.Value);

            }

            return RedirectToPage("./Index");
        }
    }
}
