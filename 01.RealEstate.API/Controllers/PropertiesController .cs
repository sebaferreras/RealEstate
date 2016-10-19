using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using _02.RealEstate.Domain.Dtos;
using _02.RealEstate.Domain.IServices;

namespace _01.RealEstate.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertiesController : ApiController
    {
        private readonly IPropertyService _service;

        public PropertiesController(IPropertyService service)
        {
            _service = service;
        }

        // GET api/properties
        [ResponseType(typeof(List<PropertyListItemDTO>))]
        public async Task<IHttpActionResult> Get()
        {
            var propertiesList = await _service.GetAll();
            return Ok(propertiesList);
        }

        // GET api/properties/5
        [ResponseType(typeof(PropertyDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var propertyDto = await _service.Get(id);

            if (propertyDto == null)
            {
                return NotFound();
            }

            return Ok(propertyDto);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
