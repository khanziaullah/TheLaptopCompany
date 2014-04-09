using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLogic
{
    public class LaptopService
    {
        private readonly LaptopRepository repository;

        public LaptopService(LaptopRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Laptop> GetLaptops()
        {
            return repository.GetLaptops();
        }
    }
}
