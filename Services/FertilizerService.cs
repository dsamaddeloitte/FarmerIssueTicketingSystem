using Farmer_Issues.Models;
using System.Data.Entity;

namespace Farmer_Issues.Services
{
    public class FertilizerService
    {
        private readonly ApplicationDbContext _context;

        public FertilizerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fertilizer> GetFertilizerAsync(int id)
        {
            return await _context.Fertilizers.FindAsync(id);
        }

        public async Task<IEnumerable<Fertilizer>> GetFertilizersAsync()
        {
            return await _context.Fertilizers.ToListAsync();
        }

        
    }


}
