using Farmer_Issues.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Farmer_Issues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IssuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpPost("FarmerCreateIssue")]
        //[Authorize(Roles = "Farmer")]
        //public async Task<ActionResult<Issue>> FarmerCreateIssue(Issue issue)
        //{
        //    issue.CreatedAt = DateTime.UtcNow;
        //    _context.Issues.Add(issue);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetIssueById), new { id = issue.Id }, issue);
        //}

        

        [HttpGet("GetAllIssue")]
        public ActionResult<IEnumerable<Issue>> GetIssues()
        {
            var issues = _context.Issues.Where(i => !i.IsResolved).ToList();
            return Ok(issues);
        }

        

        
    }
}