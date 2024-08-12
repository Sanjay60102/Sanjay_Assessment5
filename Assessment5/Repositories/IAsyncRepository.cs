using Assessment5.Entities;

namespace Assessment5.Repositories
{
    public interface ISupplierAsyncRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> GetById(string id);
        Task Update(Supplier supplier);
        Task DeleteById(string id);
        Task Add(Supplier supplier);
    }
    public interface IItemAsyncRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item> GetById(string id);
        Task Update(Item item);
        Task DeleteById(string id);
        Task Add(Item item);
    }
    public interface IPOMasterAsyncRepository
    {
        Task<List<POMaster>> GetAllAsync();
        Task<POMaster> GetById(string id);
        Task Update(POMaster pOMaster);
        Task DeleteById(string id);
        Task Add(POMaster pOMaster);
    }
}
