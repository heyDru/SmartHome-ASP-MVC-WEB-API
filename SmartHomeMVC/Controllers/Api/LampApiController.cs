using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DataService;
using Models.Model.Implementation;
using DataService.UnitOfWork.Interface;
using DataService.UnitOfWork;
using Westwind.Web.Mvc;
using SmartHomeMVC.Utilities.ModelToViewConverters;
using SmartHomeMVC.Models.ViewModels.ApiModels;

namespace SmartHomeMVC.Controllers.Api
{
    public class LampApiController : ApiController
    {
       // private DevicesContext db = new DevicesContext();
        IEnumerable<Lamp> lamps;
        IUnitOfWork dataService = new UnitOfWork();
        ModelsToIndexView modelsToIndexView = new ModelsToIndexView();


        // GET: api/LampApi
        public IEnumerable<Lamp> GetLamps()
        {
            lamps = dataService.Lamps.GetList();

            return lamps;
        }

        // GET: api/LampApi/5
        [ResponseType(typeof(Lamp))]
        public IHttpActionResult GetLamp(int id)
        {
            Lamp lampForApi = dataService.Lamps.Get(id);
            if (lampForApi == null)
            {
                return NotFound();
            }

            var lampViewModel = modelsToIndexView.GetLampIndexViewModel(lampForApi);
            var htmlString = ViewRenderer.RenderPartialView(@"~/Views/Shared/_LampConfigPartialView.cshtml", lampViewModel);

            LampApiModel lamp = new LampApiModel(lampForApi, htmlString);
            return Ok(lamp);
        }

        // PUT: api/LampApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLamp(int id, Lamp lamp)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != lamp.Id)
            {
                return BadRequest();
            }

            dataService.Lamps.Update(lamp);

            try
            {
                dataService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LampExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LampApi
        [ResponseType(typeof(Lamp))]
        public void PostLamp(Lamp lamp)
        {  
            lamp.Type = dataService.DeviceTypes.Get(1);
            dataService.Lamps.Add(lamp);
            dataService.Save();

        }

        // DELETE: api/LampApi/5
        [ResponseType(typeof(Lamp))]
        public void DeleteLamp(int Id)
        {
            dataService.Lamps.Remove(Id);
            dataService.Save();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dataService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LampExists(int id)
        {
            return dataService.Lamps.GetList().Count(e => e.Id == id) > 0;
        }

       

    }


}