using Farmer_Issues.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Farmer_Issues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ResolvedIssuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResolvedIssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResolvedIssue>> GetResolvedIssues()
        {
            var resolvedIssues = _context.ResolvedIssues.ToList();
            return Ok(resolvedIssues);
        }
    }
}
