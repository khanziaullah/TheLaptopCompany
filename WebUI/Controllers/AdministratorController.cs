using DomainLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class AdministratorController : ApiController
    {
        LaptopRepository repository;

        public AdministratorController()
        {
            repository = new SqlDataAccess.SqlLaptopRespository("connectionString");
        }

        //public AdministratorController(LaptopRepository repository)
        //{
        //    if (repository == null) throw new Exception("Administrator controller requires a repository");

        //    this.repository = repository;
        //}

        public IEnumerable GetLaptopCategory()
        {
            LaptopService service = new LaptopService(repository);

            return (from laptopCategory in service.GetLaptops()
                    select new { Name = laptopCategory.Name }).Distinct();
        }

        public IEnumerable GetLaptopDetails(string Name)
        {
            LaptopService service = new LaptopService(repository);

            return (from laptopDetails in service.GetLaptops()
                    where laptopDetails.Name == Name
                    select new { ID = laptopDetails.ID, Description = laptopDetails.Description });
        }

        public Laptop GetLaptopConfiguration(int ID)
        {
            LaptopService service = new LaptopService(repository);

            return (from laptopDetails in service.GetLaptops()
                    where laptopDetails.ID == ID
                    select laptopDetails).FirstOrDefault();
        }

        // POST api/administrator
        public void Post([FromBody]string value)
        {
        }

        // PUT api/administrator/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/administrator/5
        public void Delete(int id)
        {
        }
    }
}
