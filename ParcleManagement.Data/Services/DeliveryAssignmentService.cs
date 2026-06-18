using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.Data;
using ParcleManagement.Data.Models;

namespace ParcleManagement.Data.Services
{
    public class DeliveryAssigmentServices
    {
        private readonly AppDbContext _db;

        public DeliveryAssigmentServices(AppDbContext db) => _db = db;

        // Read All Delivery Assigment 
        public async Task<List<DeliveryAssignment>> GetAllDA()
            => await _db.DeliveryAssignments.ToListAsync();

        // Read DA by ID
        public async Task<DeliveryAssignment?> GetByDAId(int id)
            => await _db.DeliveryAssignments.FindAsync(id);

        // Create DA
        public async Task CreateDA(DeliveryAssignment da)
        {
            _db.DeliveryAssignments.Add(da);
            await _db.SaveChangesAsync();
        }

        // Update DA
        public async Task UpdateDA(DeliveryAssignment da)
        {
            _db.DeliveryAssignments.Update(da);
            await _db.SaveChangesAsync();
        }

        //Delete DA
        public async Task DeleteDA(int id)
        {
            var da = await _db.DeliveryAssignments.FindAsync(id);
            if (da != null)
            {
                _db.DeliveryAssignments.Remove(da);
                await _db.SaveChangesAsync();
            }
        }

    }
}
