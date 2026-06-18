using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.Data;
using ParcleManagement.Data.Models;

namespace ParcleManagement.Data.Services
{
    public class RoleTypeServices
    {
        private readonly AppDbContext _db;

        public RoleTypeServices (AppDbContext db) => _db = db;

        // Read All Role Type
        public async Task<List<RoleType>> GetAllRole()
            => await _db.RoleTypes.ToListAsync();

        // Read Role type by ID
        public async Task<RoleType?> GetByRoleId(int id)
            => await _db.RoleTypes.FindAsync(id);

        // Create Role 
        public async Task CreateRole(RoleType role)
        {
            _db.RoleTypes.Add(role);
            await _db.SaveChangesAsync();
        }

        // Update Role
        public async Task UpdateRole(RoleType role)
        {
            _db.RoleTypes.Update(role);
            await _db.SaveChangesAsync();
        }

        //Delete Role
        public async Task DeleteRole(int id)
        {
            var role = await _db.RoleTypes.FindAsync(id);
            if (role != null)
            {
                _db.RoleTypes.Remove(role);
                await _db.SaveChangesAsync();
            }
        }

    }
}
