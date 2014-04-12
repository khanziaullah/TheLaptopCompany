using DomainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlDataAccess
{
    public class SqlLaptopRespository : LaptopRepository
    {
        LaptopDb _db;
        public SqlLaptopRespository(string connectionString)
        {
            _db = new LaptopDb(connectionString);
        }

        public override IEnumerable<DomainLogic.Laptop> GetLaptops()
        {
            return from laptop in _db.Laptops
                   select new DomainLogic.Laptop
                   {
                       ID = laptop.ID,
                       Name = laptop.Name,
                       Description = laptop.Description,
                       Summary = laptop.Summary,
                       Memory = laptop.Memory,
                       HardDisk = laptop.HardDisk,
                       ScreenSize = laptop.ScreenSize,
                       Processor = laptop.Processor,
                       OperatingSystem = laptop.OperatingSystem,
                       Price = laptop.Price,
                       ImageUrl = laptop.ImageUrl
                   };
        }
    }
}
