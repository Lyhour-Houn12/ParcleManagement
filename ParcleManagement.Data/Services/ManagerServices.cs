using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.Data;
using ParcleManagement.Data.Models;

namespace ParcleManagement.Data.Services
{
    public class ManagerServices
    {
        private readonly AppDbContext _db;

        //Read All Manager
        public async Task<List<Manager>> GetAllManager()
            => await _db.Managers.ToListAsync();

        // Read Manager by ID
        public async Task<Manager?> GetManagerById(int id)
            => await _db.Managers.FindAsync(id);

        //Create Manager
        public async Task CreateManager(Manager manager)
        {
            _db.Managers.Add(manager);
            await _db.SaveChangesAsync();
        }

        // Update Manager
        public async Task UpdateManager(Manager manager)
        {
            _db.Managers.Update(manager);
            await _db.SaveChangesAsync();

        }

        // Delete Manager
        public async Task DeleteManager(int id)
        {
            var manager = await _db.Managers.FindAsync(id);
            if (manager != null)
            {
                _db.Managers.Remove(manager);
                await _db.SaveChangesAsync();
            }
        }



    }
}
