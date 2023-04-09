using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class CarRepository : ICarRepository<Car>
    {
        private readonly ApplicationContext _db;
        public CarRepository()
        {
            _db = new ApplicationContext();
        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _db.Cars.ToListAsync();
        }

        public async Task<Car> GetById(int id)
        {
            return await _db.Cars.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(Car item)
        {
            if (item != null)
            {
                await _db.Cars.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(Car item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Cars.FindAsync(id);
            if (item != null)
            {
                _db.Cars.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Car>> FindByNumber(string number)
        {
            return await _db.Cars.Where(r => r.Number == number).ToListAsync();
        }

        public async Task<Car> FindByName(string name)
        {
            return await _db.Cars.Where(r => r.Name == name).FirstOrDefaultAsync();
        }
    }
}
