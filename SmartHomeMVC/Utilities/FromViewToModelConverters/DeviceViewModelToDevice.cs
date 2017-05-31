using DataService.UnitOfWork.Interface;
using Models.Model.Implementation;
using SmartHomeMVC.Models.ViewModels.IndexViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Utilities.FromViewToModelConverters
{
    public class DeviceViewModelToDevice
    {
        private IUnitOfWork dataService;

        public DeviceViewModelToDevice(IUnitOfWork unitOfWork)
        {
            dataService = unitOfWork;
        }

        public void AddDevice (DevicesViewModel device)
        {
            if (device != null)
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
                        dataService.Lamps.Add(newLamp);
                        dataService.Save();
                        break;

                    case "Heater":
                        Heater newHeater = new Heater();
                        newHeater.Type = newDevice.Type;
                        newHeater.Name = newDevice.Name;
                        dataService.Heaters.Add(newHeater);
                        dataService.Save();
                        break;

                    case "TV":
                        TV newTV = new TV();
                        newTV.Type = newDevice.Type;
                        newTV.Name = newDevice.Name;
                        dataService.TVs.Add(newTV);
                        dataService.Save();
                        break;

                    default:
                        break;
                }
            }
        }

    }
}