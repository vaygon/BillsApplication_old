using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BillsApplicationDomain
{
    public class BillsDbContext : DbContext 
    {
        public BillsDbContext()
            : base("DefaultConnection")
        { 
            
        }

        public DbSet<Bill> Bills { get; set;}
    }
}