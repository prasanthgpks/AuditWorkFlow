using AuditWorkFlow.Api.Models.Domain;
using AuditWorkFlow.Api.Models.Dtos;
using AuditWorkFlow.Api.Repositories.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditWorkFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper )
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        
        public async Task<IActionResult> Get()
        {
            var customersEntities = await _customerRepository.GetCustomersAsync();

            if (customersEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<CustomerDto>>(customersEntities));
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequestDto customerRequestDto)
        {
            var model = _mapper.Map<Customer>(customerRequestDto);

            var customer = await _customerRepository.AddCustomerAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = customer.Id } , _mapper.Map<CustomerDto>(customer));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CustomerRequestDto customerRequestDto)
        {
            var model = _mapper.Map<Customer>(customerRequestDto);

            var customer = await _customerRepository.UpdateCustomerAsync(id, model);

            if (customer == null) { return NotFound(); }
            return CreatedAtAction(nameof(GetById), new { id = customer?.Id }, _mapper.Map<CustomerDto>(customer));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var customer = await _customerRepository.DeleteAsync(id);

            if (customer == null) { return NotFound(); }

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

    }
}
