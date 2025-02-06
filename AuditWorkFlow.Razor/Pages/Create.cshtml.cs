using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AuditWorkFlow.Razor.Data;
using AuditWorkFlow.Razor.Models.Domain;
using AuditWorkFlow.Razor.Models.Dtos;
using AuditWorkFlow.Razor.Repositories.Abstractions;
using AutoMapper;
using AuditWorkFlow.Razor.Repositories;

namespace AuditWorkFlow.Razor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CreateModel(ICustomerRepository _customerRepository, IMapper _mapper)
        {
            customerRepository = _customerRepository;
            mapper = _mapper;
        }
        [BindProperty]
        public CustomerDto CustomerDto { get; set; } = default!;       

        public IActionResult OnGet()
        {
            return Page();
        }

        //[BindProperty]
        //public Customer Customer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var id = customerRepository.AddCustomerAsync(mapper.Map<Customer>(CustomerDto));
            

            return RedirectToPage("./Index");
        }
    }
}
