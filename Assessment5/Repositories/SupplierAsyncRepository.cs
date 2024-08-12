using Assessment5.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Assessment5.Repositories
{
    public class SupplierAsyncRepository : ISupplierAsyncRepository
    {
        private readonly PODbContext _context;
        public SupplierAsyncRepository(PODbContext pODbContext)
        {
            _context = pODbContext;
        }
        public async Task Add(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetById(string id)
        {
            return await _context.Suppliers.SingleOrDefaultAsync(s=>s.SupplierNo==id);
        }
        public async Task DeleteById(string id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
