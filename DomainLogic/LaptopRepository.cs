using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLogic
{
    public abstract class LaptopRepository
    {
        public abstract IEnumerable<Laptop> GetLaptops();
    }
}
