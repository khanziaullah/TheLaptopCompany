using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SqlDataAccess
{
    public class LaptopDb : DbContext
    {
        public LaptopDb()
            : base(nameOrConnectionString: "LaptopDb")
        {

        }
        public DbSet<Laptop> Laptops { get; set; }
    }
}
