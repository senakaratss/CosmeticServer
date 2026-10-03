using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CosmeticServer.API.Data.Context;
using CosmeticServer.API.Data.Entities;
using CosmeticServer.API.Dtos.ContactMessageDtos;
using System.Text;
using Microsoft.OpenApi.Writers;

namespace CosmeticServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactMessagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactMessage>>> GetContactMessages()
        {
            return await _context.ContactMessages.ToListAsync();
        }

        // GET: api/ContactMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMessage>> GetContactMessage(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);

            if (contactMessage == null)
            {
                return NotFound();
            }

            return contactMessage;
        }
        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);
            if (contactMessage == null)
            {
                return NotFound();
            }
            contactMessage.IsRead = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/ContactMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactMessage(int id, UpdateContactMessageDto contactMessageDto)
        {
            var contactMessage = new ContactMessage
            {
                Id = contactMessageDto.Id,
                Name = contactMessageDto.Name,
                Email = contactMessageDto.Email,
                Message = contactMessageDto.Message,
                IsRead = contactMessageDto.IsRead
            };

            if (id != contactMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactMessage>> PostContactMessage(CreateContactMessageDto contactMessageDto)
        {
            var contactMessage = new ContactMessage
            {
                Name = contactMessageDto.Name,
                Email = contactMessageDto.Email,
                Message = contactMessageDto.Message,
                IsRead = contactMessageDto.IsRead
            };

            _context.ContactMessages.Add(contactMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactMessage", new { id = contactMessage.Id }, contactMessage);
        }

        // DELETE: api/ContactMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            var contactMessage = await _context.ContactMessages.FindAsync(id);
            if (contactMessage == null)
            {
                return NotFound();
            }

            _context.ContactMessages.Remove(contactMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactMessageExists(int id)
        {
            return _context.ContactMessages.Any(e => e.Id == id);
        }
    }
}
