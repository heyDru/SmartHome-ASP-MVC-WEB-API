using Models.Model.Implementation;
using SmartHomeMVC.Models.ViewModels.IndexViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models.ViewModels.ApiModels
{
    public class TvApiModel
    {
        public TVIndexViewModel TV { get; set; }
        public string HTML { get; set; }
        public TvApiModel(TVIndexViewModel tv, string html)
        {
            TV = tv;
            HTML = html;
        }
    }
}