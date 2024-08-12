using Assessment5.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment5.Repositories
{
    public class POMasterAsyncRepository : IPOMasterAsyncRepository
    {
        private readonly PODbContext _context;
        public POMasterAsyncRepository(PODbContext pODbContext)
        {
            _context = pODbContext;
        }

        public async Task Add(POMaster pOMaster)
        {
            await _context.POMasters.AddAsync(pOMaster);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var result = await _context.POMasters.FindAsync(id);
            _context.POMasters.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<POMaster>> GetAllAsync()
        {
            return await _context.POMasters.ToListAsync();
        }

        public async Task<POMaster> GetById(string id)
        {
            return await _context.POMasters.SingleOrDefaultAsync(p=>p.PONo == id);
        }

        public async Task Update(POMaster pOMaster)
        {
            _context.POMasters.Update(pOMaster);
            await _context.SaveChangesAsync();
        }
    }
}
