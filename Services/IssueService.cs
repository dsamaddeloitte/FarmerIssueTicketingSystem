using Farmer_Issues.Models;
using System.Data.Entity;

namespace Farmer_Issues.Services
{
    public class IssueService
    {
        private readonly ApplicationDbContext _context;

        public IssueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Issue> GetIssueAsync(int id)
        {
            return await _context.Issues.FindAsync(id);
        }

        public async Task<IEnumerable<Issue>> GetIssuesAsync()
        {
            return await _context.Issues.ToListAsync();
        }

        public async Task CreateIssueAsync(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
        }

        
    }

}
