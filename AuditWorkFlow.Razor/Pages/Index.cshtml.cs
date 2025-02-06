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
using AuditWorkFlow.Razor.Models.Dtos;

namespace AuditWorkFlow.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public IndexModel(ICustomerRepository _customerRepository, IMapper _mapper)
        {

            customerRepository = _customerRepository;
            mapper = _mapper;
        }

        public IList<Customer> Customers { get;set; } = default!;

        public IList<CustomerDto> CustomerDtos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customers = await customerRepository.GetCustomersAsync();

            CustomerDtos = Customers.Select(c => mapper.Map<CustomerDto>(c)).ToList();
        }
    }
}
