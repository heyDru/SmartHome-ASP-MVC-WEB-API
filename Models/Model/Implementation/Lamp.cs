using Models.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model.Implementation
{
    public class Lamp : Device, ILightable
    {
        public Lamp()
        {
            Intensity = 0;
        }

        public Lamp(DeviceType type, string name) : base(type, name)
        {
            Intensity = 0;
        }

        public int Intensity { get; set; }
    }
}
