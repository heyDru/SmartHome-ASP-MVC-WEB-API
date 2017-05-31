using Models.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Models.Model.Implementation
{

    public class TV : Device/*, ITV*/
    {
        public TV()
        {
            Volume = 25;
        }

        public Channel CurrentChannel { get; set; }

        public TV(DeviceType type, string name) : base(type,name)
        {
            Volume = 25;
        }

        public int Volume { get; set; }
    }
} 
