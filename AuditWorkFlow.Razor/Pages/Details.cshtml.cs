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
using AuditWorkFlow.Razor.Models.Dtos;
using AutoMapper;

namespace AuditWorkFlow.Razor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public DetailsModel(ICustomerRepository _customerRepository, IMapper _mapper)
        {
            customerRepository = _customerRepository;
            mapper = _mapper;
        }

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

                CustomerDto.Status = Enum.GetName(typeof(AuditWorkFlow.Razor.Models.Enums.Common.StatusCodes), customer.StatusCode);

            }
            return Page();
        }
    }
}
