using Model.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Implementation
{
    public class Heater : Device, ITemperature
    {
        public Heater(string type) : base(type)
        {
            Temperature = 20;
        }

        public int Temperature { get; set; }
    }
}
