using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ApplicationContext _db;
        public ProductRepository()
        {
            this._db = new ApplicationContext();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(Product item)
        {
            if (item != null)
            {
                await _db.Products.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(Product item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Products.FindAsync(id);
            if (item != null)
            {
                _db.Products.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }


        public async Task<IEnumerable<Product>> GetByNameList(string name)
        {
            return await _db.Products.Where(r => r.Name == name).ToListAsync();
        }

        public async Task<Product> GetByNameFirstOrDefault(string name)
        {
            return await _db.Products.FirstOrDefaultAsync(r => r.Name == name);

        }
    }
}
