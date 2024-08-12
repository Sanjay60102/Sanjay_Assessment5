using Assessment5.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment5.Repositories
{
    public class ItemAsyncRepository : IItemAsyncRepository
    {
        private readonly PODbContext _context;
        public ItemAsyncRepository(PODbContext pODbContext)
        {
            _context = pODbContext;
        }
        public async Task Add(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetById(string id)
        {
            return await _context.Items.SingleOrDefaultAsync(i=>i.ItCode==id);
        }

        public async Task Update(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
