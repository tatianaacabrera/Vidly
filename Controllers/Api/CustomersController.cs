using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.Dto;
using AutoMapper;
using System.Net;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly VidlyContext _context;
        private readonly IMapper _mapper;

        public CustomersController(VidlyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
          if (_context.Customer == null)
          {
              return NotFound();
          }
            return await _context.Customer.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }


        // POST: api/Customers
        [HttpPost]
        public ActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<Customer>(customerDto);

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}