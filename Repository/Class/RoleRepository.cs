using Intership.Models;
using Intership.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intership.Repository.Class
{
    public class RoleRepository : IRoleRepository<Role>
    {
        private readonly ApplicationContext _db;

        public RoleRepository()
        {
            this._db = new ApplicationContext();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _db.Roles.ToListAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return await _db.Roles.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task Create(Role item)
        {
            if (item != null)
            {
                await _db.Roles.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Update(Role item)
        {
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var role = await _db.Roles.FindAsync(id);
            if (role != null)
            {
                _db.Roles.Remove(role);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Role> GetByName(string name)
        {
            return await _db.Roles.SingleOrDefaultAsync(r => r.Name == name);
        }
    }
}
