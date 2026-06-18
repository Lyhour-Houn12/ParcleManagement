using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.Data;
using ParcleManagement.Data.Models;

namespace ParcleManagement.Data.Services
{
    public class UserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db) => _db = db;


        // Read all users
        public async Task<List<User>> GetAllUsers()
            => await _db.Users.ToListAsync();

        // Read one user by ID
        public async Task<User?> GetByUserId(int id)
            => await _db.Users.FindAsync(id);

        // Create a new user
        public async Task CreateUser(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();   
        }

        // Update user 
        public async Task UpdateUser(User user)
        {
            _db.Users.Update(user);
           await _db.SaveChangesAsync();
        }

        // Delete user
        public async Task DeleteUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)  
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }
    }
}
