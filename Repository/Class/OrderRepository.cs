using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class OrderRepository : IOrderRepository<Order>
    {
        private readonly ApplicationContext _db;
        public OrderRepository()
        {
            _db = new ApplicationContext();
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _db.Orders.Include(x => x.Market)
                                   .Include(x => x.Driver)
                                   .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _db.Orders.Include(x => x.Market)
                                    .Include(x => x.Driver)
                                    .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(Order item)
        {
            if (item != null)
            {
                await _db.Orders.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Orders.FindAsync(id);
            if (item != null)
            {
                _db.Orders.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Order>> GetByName(string name)
        {
            return await _db.Orders.Include(x => x.Market)
                                   .Include(x => x.Driver)
                                   .Where(x => x.Market.Name == name)
                                   .ToListAsync();
        }
    }
}
