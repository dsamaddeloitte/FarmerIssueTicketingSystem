using Farmer_Issues.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Entity;

namespace Farmer_Issues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Farmer")]
    [Authorize(Policy = "FarmerOnly")]
    public class FarmersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("FarmerDetails")]
        public async Task<ActionResult<Farmer>> CreateFarmer(Farmer farmer)
        {
            try
            {
                _context.Farmers.Add(farmer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return CreatedAtAction(nameof(GetFarmers), new { id = farmer.Id }, farmer);
        }

        [HttpPost("FarmerCreateIssue")]
        [Authorize(Roles = "Farmer")]
        public async Task<ActionResult<Issue>> FarmerCreateIssue(Issue issue)
        {
            issue.CreatedAt = DateTime.UtcNow;
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIssueById), new { id = issue.Id }, issue);
        }

        [HttpGet("{id}/GetIssueDetails")]
        public async Task<ActionResult<Issue>> GetIssueById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return issue;
        }
        [HttpGet("GetFarmerDetails")]
        public ActionResult<IEnumerable<Farmer>> GetFarmers()
        {
            //List<Farmer> far = new List<Farmer>();

            try
            {
                var far = _context.Farmers.ToList();
                return Ok(far);
                //return await _context.Farmers.ToListAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error : {ex.Message}");
            }
        }

        [HttpPut("{id}/UpdateIssue")]
        public async Task<IActionResult> UpdateFarmerRecord(int id, [FromBody] Issue updatedIssue)
        {
            try
            {
                var issue = await _context.Issues.FindAsync(id);
                if (issue == null)
                {
                    return NotFound();
                }
                issue.Description = updatedIssue.Description;
                issue.IsResolved = updatedIssue.IsResolved;
                issue.CreatedAt = updatedIssue.CreatedAt;
                
                await _context.SaveChangesAsync();
                return NoContent();


                //return await _context.Farmers.ToListAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error : {ex.Message}");
            }
        }

        [HttpDelete("{id}/DeleteIssue")]
        public async Task<IActionResult> DeleteIssue(int id)
        {

            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            _context.Issues.Remove(issue);
            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error : {ex.Message}");
            }

        }
        
    
        //[HttpGet]
        //public async Task<ActionResult<Farmer>> GetFarmers(int id)
        //{
        //    try
        //    {
        //        var farmer = await _context.Farmers.FindAsync(id);
        //        if (farmer == null)
        //        {
        //            return NotFound();
        //        }
        //        return farmer;
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal Server error : {ex.Message}");
        //    }
        //}

        // ...
    }

}
