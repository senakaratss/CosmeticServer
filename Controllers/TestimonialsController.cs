using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CosmeticServer.API.Data.Context;
using CosmeticServer.API.Data.Entities;
using CosmeticServer.API.Dtos.TestimonialsDtos;

namespace CosmeticServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestimonialsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Testimonials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }

        [HttpGet("visibleTestimonials")]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetVisibleTestimonials()
        {
            return await _context.Testimonials.Where(t => t.Visibility).ToListAsync();
        }
        [HttpPatch("{id}/visibility")]
        public async Task<IActionResult> UpdateVisibility(int id, UpdateVisibilityDto visibility)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            testimonial.Visibility = visibility.Visibility;
            await _context.SaveChangesAsync();
            return NoContent();
        }

            // GET: api/Testimonials/5
            [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);

            if (testimonial == null)
            {
                return NotFound();
            }

            return testimonial;
        }

        // PUT: api/Testimonials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = new Testimonial
            {
                Id = updateTestimonialDto.Id,
                FullName = updateTestimonialDto.FullName,
                Title=updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Rating = updateTestimonialDto.Rating,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Visibility=updateTestimonialDto.Visibility
               
            };

            if (id != testimonial.Id)
            {
                return BadRequest();
            }

            _context.Entry(testimonial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestimonialExists(id))
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

        // POST: api/Testimonials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Testimonial>> PostTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = new Testimonial
            {
                FullName = createTestimonialDto.FullName,
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                Rating = createTestimonialDto.Rating,
                ImageUrl = createTestimonialDto.ImageUrl,
                Visibility=createTestimonialDto.Visibility
            };
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestimonial", new { id = testimonial.Id }, testimonial);
        }

        // DELETE: api/Testimonials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }

            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestimonialExists(int id)
        {
            return _context.Testimonials.Any(e => e.Id == id);
        }
    }
}
