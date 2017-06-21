using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataService;
using Models.Model.Implementation;
using DataService.UnitOfWork.Interface;
using DataService.UnitOfWork;
using SmartHomeMVC.Utilities.ModelToViewConverters;
using SmartHomeMVC.Models.ViewModels.IndexViewModels;
using SmartHomeMVC.Models.ViewModels.ApiModels;
using Westwind.Web.Mvc;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers.Api
{
    public class TVsApiController : ApiController
    {
        private DevicesContext db = new DevicesContext();
        IEnumerable<TV> tvs;
        IUnitOfWork dataService = new UnitOfWork();
        ModelsToIndexView modelsToIndexView = new ModelsToIndexView();

        // GET: api/TVsApiController
        public IEnumerable<TvApiModel> GetTvs()
        {
            var tvsToView = dataService.TVs.GetList().ToList();
            List<TVIndexViewModel> tvsViewModel = modelsToIndexView.GetTVsViewModelsList(tvsToView);
            List<TvApiModel> Tvs = new List<TvApiModel>();

            foreach(TVIndexViewModel tv in tvsViewModel)
            {
                var htmlString = ViewRenderer.RenderPartialView(@"~/Views/Shared/_TVIndexPartialView.cshtml", tv);
                Tvs.Add(new TvApiModel(tv, htmlString));
            }
            return Tvs;
        }

        // GET: api/TVsApiController/5
        [ResponseType(typeof(TV))]
        public IHttpActionResult GetTV(int id)
        {
            TV tvForApi = dataService.TVs.Get(id);
            if (tvForApi == null)
            {
                return NotFound();
            }
            var tvViewModel = modelsToIndexView.GetTVViewModel(tvForApi);
            tvViewModel.CurrentChannel = modelsToIndexView.GetChannelViewModel(tvForApi.CurrentChannel);
            var channels = dataService.Channels.GetList();
            var channelsViewModels = modelsToIndexView.GetChannelViewModelList(channels);

            tvViewModel.ChannelsDropDownList = new SelectList(
                channelsViewModels,
                "ChannelId",
                "ChannelName",
                selectedValue: tvViewModel.CurrentChannel.ChannelId
                );

            var htmlString = ViewRenderer.RenderPartialView(@"~/Views/Shared/_TVConfigPartialView.cshtml", tvViewModel);
            TvApiModel tv = new TvApiModel(tvViewModel, htmlString);
            return Ok(tv);
        }

        // PUT: api/TVs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTV(int id, TV tv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tv.Id)
            {
                return BadRequest();
            }

            dataService.TVs.Update(tv);

            try
            {
                dataService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVExists(id))
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

        // POST: api/TVs
        [ResponseType(typeof(TV))]
        public void PostTV(TV tV)
        {
            tV.Type = dataService.DeviceTypes.Get(3);
            dataService.TVs.Add(tV);
            dataService.Save();

        }

        // DELETE: api/TVs/5
        [ResponseType(typeof(TV))]
        public IHttpActionResult DeleteTV(int id)
        {
            TV tV = dataService.TVs.Get(id);
            if (tV == null)
            {
                return NotFound();
            }

            dataService.TVs.Remove(tV.Id);
            dataService.Save();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TVExists(int id)
        {
            return dataService.TVs.GetList().Count(e => e.Id == id) > 0;

        }
    }
}