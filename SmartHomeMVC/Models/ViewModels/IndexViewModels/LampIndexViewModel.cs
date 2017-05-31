using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models.ViewModels.IndexViewModels
{
    public class LampIndexViewModel
    {
        public LampIndexViewModel()
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

        [Range(0, 100,ErrorMessage = "Value for must be between {1} and {2}.")]
        public int Intensity { get; set; }
    }
}