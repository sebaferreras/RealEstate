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
    public class BrokersController : ApiController
    {
        private readonly IBrokerService _service;

        public BrokersController(IBrokerService service)
        {
            this._service = service;
        }

        // GET api/properties
        [ResponseType(typeof(List<BrokerDTO>))]
        public async Task<IHttpActionResult> Get()
        {
            var propertiesList = await _service.GetAll();
            return Ok(propertiesList);
        }

        // GET api/properties/5
        [ResponseType(typeof(BrokerDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var brokerDto = await _service.Get(id);

            if (brokerDto == null)
            {
                return NotFound();
            }

            return Ok(brokerDto);
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
