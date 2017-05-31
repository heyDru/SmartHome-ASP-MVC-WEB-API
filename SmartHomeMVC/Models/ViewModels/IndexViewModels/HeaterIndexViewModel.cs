using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models.ViewModels.IndexViewModels
{
    public class HeaterIndexViewModel
    {
        public HeaterIndexViewModel()
        {
            Temperature = 20;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Device Electricity Consumption")]
        public double Consumption { get; set; }

        [Required]
        public bool TurnOn { get; set; }

        [Range(12, 35, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Temperature { get; set; }
    }
}