using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class LaptopViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Memory { get; set; }
        public int HardDisk { get; set; }
        public int ScreenSize { get; set; }
        public string Processor { get; set; }
        public string OperatingSystem { get; set; }
        public decimal Price { get; set; }

        public LaptopViewModel(DomainLogic.Laptop laptop)
        {
            this.ID = laptop.ID;
            this.Name = laptop.Name;
            this.Description = laptop.Description;
            this.Summary = laptop.Summary;
            this.Memory = String.Format(laptop.Memory.ToString() + "GB");
            this.HardDisk = laptop.HardDisk;
            this.ScreenSize = laptop.ScreenSize;
            this.Processor = laptop.Processor;
            this.OperatingSystem = laptop.OperatingSystem;
            this.Price = laptop.Price;
        }
    }
}