using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLogic
{
    public class Laptop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public int Memory { get; set; }
        public int HardDisk { get; set; }
        public int ScreenSize { get; set; }
        public string Processor { get; set; }
        public string OperatingSystem { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
