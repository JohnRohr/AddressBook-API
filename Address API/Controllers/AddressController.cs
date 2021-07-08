using Address_API.Models;
using Address_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _addressRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddresses(int id)
        {
            return await _addressRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Address>> PostBooks([FromBody] Address address)
        {
            var newAddress = await _addressRepository.Create(address);
            return CreatedAtAction(nameof(GetAddresses), new { id = newAddress.ID }, newAddress);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Address address)
        {
            if (id != address.ID)
            {
                return BadRequest();
            }

            await _addressRepository.Update(address);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var addressToDelete = await _addressRepository.Get(id);
            if (addressToDelete == null)
                return NotFound();

            await _addressRepository.Delete(addressToDelete.ID);
            return NoContent();
        }
    }
}