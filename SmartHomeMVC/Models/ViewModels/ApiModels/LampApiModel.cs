using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models.ViewModels.ApiModels
{
    public class LampApiModel
    {
        public Lamp Lamp{ get; set; }
        public string HTML { get; set; }
        public LampApiModel(Lamp lamp, string html)
        {
            Lamp = lamp;
            HTML = html;
        }
    }
}