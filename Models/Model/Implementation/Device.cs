using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Model.Implementation
{
    public class Device
    {
        protected Device()
        {

        }
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Devie Electricity Consumption")]
        public double Consumption { get; set; }
        public bool TurnOn { get; set; }

        public DeviceType Type { get; set; }

        public Device(DeviceType type,string name)
        {
            Type = type;
            Name = name;
            TurnOn = false;
        }

        public void Switch()
        {
            if (TurnOn)
            {
                TurnOn = false;
            }
            else
            {
                TurnOn = true;
            }
        }
    }
}
