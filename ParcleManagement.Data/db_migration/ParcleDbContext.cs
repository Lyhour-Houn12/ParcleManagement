using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcleManagement.Data.db_migration
{
    public class ParcleDbContext : DbContext
    {
        public ParcleDbContext(DbContextOptions<ParcleDbContext> options)
            : base(options)
        {
        }
    }
}
