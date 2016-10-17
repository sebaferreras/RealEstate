using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _02.RealEstate.Domain.Entities;
using _02.RealEstate.Domain.IServices;

namespace _01.RealEstate.API.Controllers
{
    public class PropertiesController : ApiController
    {
        private IPropertyService service;

        public PropertiesController(IPropertyService service)
        {
            this.service = service;
        }

        // GET api/values
        public IEnumerable<Property> Get()
        {
            return service.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
