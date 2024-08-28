using Farmer_Issues.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Security.Claims;

namespace Farmer_Issues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Fertilzer")]
    [Authorize(Policy = "FertilizerOnly")]
    public class FertilizersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FertilizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("InsertFertilizerDetails")]
        public async Task<ActionResult<Fertilizer>> CreateFertilizer(Fertilizer fertilizer)
        {
            _context.Fertilizers.Add(fertilizer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFertilizers), new { id = fertilizer.Id }, fertilizer);
        }

        [HttpGet("GetFertilizerDetails")]
        public async Task<ActionResult<IEnumerable<Fertilizer>>> GetFertilizers(int id)
        {

            try
            {
                var ferti = await _context.Fertilizers.FindAsync(id);
                return Ok(ferti);
                //return await _context.Farmers.ToListAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error : {ex.Message}");
            }
            //return await _context.Fertilizers.ToListAsync();
        }
        [HttpPut("{id}/FertilizerPickIssue")]
        [Authorize(Roles = "Fertilizer")]
        public async Task<IActionResult> PickIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            issue.FertilizerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Assuming the fertilizer ID is in the token
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}/ResolvebyFertilizer")]
        [Authorize(Roles = "Fertilizer")]
        public async Task<IActionResult> ResolveIssue(int id, [FromBody] string resolution)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            if (issue.FertilizerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Forbid("You can only resolve issues you picked up.");
            }

            issue.IsResolved = true;

            var resolvedIssue = new ResolvedIssue
            {
                IssueId = issue.Id,
                Resolution = resolution,
                ResolvedDate = DateTime.UtcNow,
                FertilizerId = issue.FertilizerId.Value
            };

            _context.ResolvedIssues.Add(resolvedIssue);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // ...
    }

}
