using Model.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Implementation
{
    public class Lamp : Device, ILightable
    {
        public Lamp(string type) : base(type)
        {
            Intensity = 0;
        }
        public int Intensity { get; set; }
    }
}
