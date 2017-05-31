using Models.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model.Implementation
{
    public class Heater : Device, ITemperature
    {
        public Heater()
        {
            Temperature = 20;

        }
        public Heater(DeviceType type, string name) : base(type, name)
        {
            Temperature = 20;
        }

        public int Temperature { get; set; }
    }
}
