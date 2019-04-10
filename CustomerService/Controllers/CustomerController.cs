using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Models;
using CustomerService.Repositories;
using CustomerService.CommandHandlers;
using CustomerService.Commands;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _repo;
        ICustomerCommandHandler _handler;
        public CustomerController(ICustomerRepository repo, ICustomerCommandHandler handler)
        {
            _repo = repo;
            _handler = handler;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
            return Ok(_repo.GetUsers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            return Ok(_repo.GetUserByID(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Users>> Post([FromBody] CustomerCreatedCommand value)
        {
            _handler.HandleCustomerCreated(value);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
