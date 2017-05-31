using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Models.ViewModels.IndexViewModels
{
    public class DevicesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Devie Name or Location")]
        [StringLength(50,ErrorMessage = "50 characters is enough ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Devie Electicity Consumption")]
        public double Consumption { get; set; }

        [Required(ErrorMessage = "Enter Devie Type")]
        public int TypeId { get; set; }
    }
}