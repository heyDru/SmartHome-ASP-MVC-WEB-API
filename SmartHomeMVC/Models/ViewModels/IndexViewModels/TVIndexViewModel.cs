using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeMVC.Models.ViewModels.IndexViewModels
{
    public class TVIndexViewModel
    {
        public TVIndexViewModel()
        {

        }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Devie Name or Location")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Devie Electricity Consumption")]
        public double Consumption { get; set; }

        [Required]
        public bool TurnOn { get; set; }

        public ChannelViewModel CurrentChannel { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Volume { get; set; }

        //public ICollection<Channel> Channels { get; set; }

        public SelectList ChannelsDropDownList { get; set; }

        public DeviceType Type { get; set; }
    }
}