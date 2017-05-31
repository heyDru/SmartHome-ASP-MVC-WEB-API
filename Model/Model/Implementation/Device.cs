using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Implementation
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Consumption { get; set; }
        public bool TurnOn { get; set; }
        public string Type { get; set; }

        public Device(string type)
        {
            Type = type;
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
