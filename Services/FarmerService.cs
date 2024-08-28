using Farmer_Issues.Models;
using System.Data.Entity;

namespace Farmer_Issues.Services
{
    public class FarmerService
    {
        private readonly ApplicationDbContext _context;

        public FarmerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Farmer> GetFarmerAsync(int id)
        {
            return await _context.Farmers.FindAsync(id);
        }

        public async Task<IEnumerable<Farmer>> GetFarmersAsync()
        {
            return await _context.Farmers.ToListAsync();
        }

       
    }

}
