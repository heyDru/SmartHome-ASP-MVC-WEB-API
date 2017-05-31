using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models.ViewModels.IndexViewModels
{
    public class IndexViewModel
    {
        public ICollection<LampIndexViewModel> Lamps { get; set; }
        public ICollection<HeaterIndexViewModel> Heaters { get; set; }
        public ICollection<TVIndexViewModel> TVs { get; set; }
        public ICollection<DeviceTypeIndexViewModel> DeviceTypes { get; set; }
        public ICollection<Channel> Channels { get; set; }
        public DevicesViewModel Device { get; set; }
    }
}