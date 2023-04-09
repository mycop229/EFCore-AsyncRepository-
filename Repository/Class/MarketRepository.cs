using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class MarketRepository : IMarketRepository<Market>
    {
        private readonly ApplicationContext _db;
        public MarketRepository()
        {
            _db = new ApplicationContext();
        }
        public async Task<IEnumerable<Market>> GetAll()
        {
            return await _db.Markets.ToListAsync();
        }

        public async Task<Market> GetById(int id)
        {
            return await _db.Markets.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(Market item)
        {
            if (item != null)
            {
                await _db.Markets.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(Market item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Markets.FindAsync(id);
            if (item != null)
            {
                _db.Markets.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Market>> GetByNameToList(string name)
        {
            return await _db.Markets.Where(r => r.Name == name).ToListAsync();

        }

        public async Task<IEnumerable<Market>> GetByAddress(string name)
        {
            return await _db.Markets.Where(r => r.Address == name).ToListAsync();
        }

        public async Task<Market> GetByNameFirstOrDefault(string name)
        {
            return await _db.Markets.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
