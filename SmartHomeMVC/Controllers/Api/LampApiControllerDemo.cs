using DataService.UnitOfWork;
using DataService.UnitOfWork.Interface;
using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHomeMVC.Controllers.Api
{
    public class LampApiControllerDemo : ApiController
    {
        IUnitOfWork dataService;
        IEnumerable<Lamp> lamps;
        IEnumerable<Heater> heaters;
        IEnumerable<TV> tvs;
        IEnumerable<DeviceType> deviceTypes;

        public LampApiControllerDemo()
        {
            dataService = new UnitOfWork();
        }
        //http://localhost:53974/api/apihome
        // GET: api/ApiHome
        public IEnumerable<Lamp> Get()
        {
            lamps =dataService.Lamps.GetList();

            return lamps;
        }

        // GET: api/ApiHome/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApiHome
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApiHome/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiHome/5
        [HttpDelete]
        public void Delete(int lampId)
        {
            dataService.Lamps.Remove(lampId);
            dataService.Save();
        }
    }
}
