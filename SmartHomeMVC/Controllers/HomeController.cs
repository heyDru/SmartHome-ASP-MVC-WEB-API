using AutoMapper;
using DataService.UnitOfWork;
using DataService.UnitOfWork.Interface;
using Models.Model.Implementation;
using SmartHomeMVC.Models.ViewModels.IndexViewModels;
using SmartHomeMVC.Utilities.ModelToViewConverters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork dataService;
        ModelsToIndexView mapperModelToIndexView;
        ICollection<Lamp> lamps;
        ICollection<Heater> heaters;
        ICollection<TV> tvs;
        ICollection<DeviceType> deviceTypes;
        IndexViewModel indexViewModel;

        public HomeController()
        {
            dataService = new UnitOfWork();
            mapperModelToIndexView = new ModelsToIndexView();
        }

        public ActionResult Index()
        {
            lamps = dataService.Lamps.GetList();
            heaters = dataService.Heaters.GetList();
            tvs = dataService.TVs.GetList();
            deviceTypes = dataService.DeviceTypes.GetList();

            indexViewModel = mapperModelToIndexView.GetIndexViewModel(lamps, heaters, tvs, deviceTypes);

            return View(indexViewModel);
        }

        [HttpPost]
        public ActionResult Index(DevicesViewModel device)
        {
            if (device.Name != null)
            {
                Device newDevice = new Device(dataService.DeviceTypes.Get(device.TypeId), device.Name)
                {
                    Consumption = device.Consumption
                };
                switch (newDevice.Type.Name)
                {
                    case "Lamp":
                        Lamp newLamp = new Lamp();
                        newLamp.Type = newDevice.Type;
                        newLamp.Name = newDevice.Name;
                        newLamp.Consumption = newDevice.Consumption;
                        dataService.Lamps.Add(newLamp);
                        dataService.Save();
                        break;

                    case "Heater":
                        Heater newHeater = new Heater();
                        newHeater.Type = newDevice.Type;
                        newHeater.Name = newDevice.Name;
                        newHeater.Consumption = newDevice.Consumption;
                        dataService.Heaters.Add(newHeater);
                        dataService.Save();
                        break;

                    case "TV":
                        TV newTV = new TV();
                        newTV.Type = newDevice.Type;
                        newTV.Name = newDevice.Name;
                        newTV.Consumption = newDevice.Consumption;

                        dataService.TVs.Add(newTV);
                        dataService.Save();
                        break;

                    default:
                        break;
                }
            }
            //lamps = dataService.Lamps.GetList();
            //heaters = dataService.Heaters.GetList();
            //tvs = dataService.TVs.GetList();
            //deviceTypes = dataService.DeviceTypes.GetList();

            //indexViewModel = mapperModelToIndexView.GetIndexViewModel(lamps, heaters, tvs, deviceTypes);

            //indexViewModel.Device = device;
            //ModelState.Clear();
            return RedirectToAction("Index");
        }

        #region Lamp Controller

        public ActionResult DeleteLamp(int lampId)
        {
            dataService.Lamps.Remove(lampId);
            dataService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ConfigLamp(int lampId)
        {
            Lamp lamp = dataService.Lamps.Get(lampId);

            if (lamp != null)
            {
                var lampViewModel = mapperModelToIndexView.GetLampIndexViewModel(lamp);

                return PartialView("_LampConfigPartialView", lampViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ConfigLamp(LampIndexViewModel lampViewModel)
        {
            if (ModelState.IsValid)
            {
                Lamp lamp = dataService.Lamps.Get(lampViewModel.Id);


                lamp.Consumption = lampViewModel.Consumption;
                lamp.Name = lampViewModel.Name;
                lamp.Intensity = lampViewModel.Intensity;
                lamp.TurnOn = lampViewModel.TurnOn;

                dataService.Lamps.Update(lamp);
                dataService.Save();

                return PartialView("_LampIndexPartialView", lampViewModel);

            }

            else
            {
                return PartialView("_LampConfigPartialView", lampViewModel);
            }
        }

        #endregion

        #region Heater Controller

        public ActionResult DeleteHeater(int heaterId)
        {
            dataService.Heaters.Remove(heaterId);
            dataService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ConfigHeater(int heaterId)
        {

            Heater heater = dataService.Heaters.Get(heaterId);

            if (heater != null)
            {
                HeaterIndexViewModel heaterViewModel = mapperModelToIndexView.GetHeaterViewModel(heater);

                return PartialView("_HeaterConfigPartialView", heaterViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ConfigHeater(HeaterIndexViewModel heaterViewModel)
        {
            if (ModelState.IsValid)
            {
                Heater heater = dataService.Heaters.Get(heaterViewModel.Id);
                heater.Consumption = heaterViewModel.Consumption;
                heater.Name = heaterViewModel.Name;
                heater.Temperature = heaterViewModel.Temperature;
                heater.TurnOn = heaterViewModel.TurnOn;

                dataService.Heaters.Update(heater);
                dataService.Save();

                return PartialView("_HeaterIndexPartialView", heaterViewModel);
            }

            else
            {
                return PartialView("_HeaterConfigPartialView", heaterViewModel);
            }
        }

        #endregion

        #region TV Controller
        public ActionResult DeleteTV(int tvId)
        {
            dataService.TVs.Remove(tvId);
            dataService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ConfigTV(int tvId)
        {
            TV tv = dataService.TVs.Get(tvId);
            if (tv != null)
            {
                TVIndexViewModel tvViewModel = mapperModelToIndexView.GetTVViewModel(tv);
                tvViewModel.CurrentChannel = mapperModelToIndexView.GetChannelViewModel(tv.CurrentChannel);
                var channels = dataService.Channels.GetList();
                var channelsViewModels = mapperModelToIndexView.GetChannelViewModelList(channels);

                tvViewModel.ChannelsDropDownList = new SelectList(
                    channelsViewModels,
                    "ChannelId",
                    "ChannelName",
                    selectedValue: tvViewModel.CurrentChannel.ChannelId
                    );

                return PartialView("_TVConfigPartialView", tvViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ConfigTV(TVIndexViewModel tvViewModel)
        {
               TV tv = dataService.TVs.Get(tvViewModel.Id);

            tv.Name = tvViewModel.Name;
            tv.CurrentChannel = dataService.Channels.Get(tvViewModel.CurrentChannel.ChannelId); 
            tv.Volume = tvViewModel.Volume;
            tv.TurnOn = tvViewModel.TurnOn;
            tv.Consumption = tvViewModel.Consumption;

            dataService.TVs.Update(tv);
            dataService.Save();

            tvViewModel.CurrentChannel = mapperModelToIndexView.GetChannelViewModel(tv.CurrentChannel);

            return PartialView("_TVIndexPartialView", tvViewModel);
        }
        #endregion


        //Go WebApi

        public ActionResult GoWebApi()
        {
            return View();
        }

      

    }
}