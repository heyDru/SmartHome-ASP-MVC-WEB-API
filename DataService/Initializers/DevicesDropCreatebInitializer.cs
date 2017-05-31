using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Initializers
{
  public  class DevicesDropCreatebInitializer : CreateDatabaseIfNotExists<DevicesContext>
    {
        protected override void Seed(DevicesContext db)
        {

            DeviceType type1 = new DeviceType { Name = "Lamp" };
            DeviceType type2 = new DeviceType { Name = "Heater" };
            DeviceType type3 = new DeviceType { Name = "TV" };


            Lamp lamp1 = new Lamp(type1,"1 Lamp");
            lamp1.Intensity = 11;
            Lamp lamp2 = new Lamp(type1, "2 Lamp");
            lamp1.Intensity = 22;
            Lamp lamp3 = new Lamp(type1, "3 Lamp");
            lamp1.Intensity = 33;
            Lamp lamp4 = new Lamp(type1, "4 Lamp");
            lamp4.Intensity = 44;
            lamp4.TurnOn = true;

            Heater heater1 = new Heater(type2, "bigRoom Heater");
            heater1.Temperature = 22;

            TV tv = new TV(type3, "Room Tv");
            tv.Volume = 55;

            Channel ch1 = new Channel() {ChannelName= "MTV" };
            Channel ch2 = new Channel { ChannelName = "Discovery" };
            Channel ch3 = new Channel { ChannelName = "Euronews" };

            db.Channels.Add(ch1);
            db.Channels.Add(ch2);
            db.Channels.Add(ch3);
            
            tv.CurrentChannel = ch2;

            db.DeviceTypes.Add(type1);
            db.DeviceTypes.Add(type2);
            db.DeviceTypes.Add(type3);


            db.Lamps.Add(lamp1);
            db.Lamps.Add(lamp2);
            db.Lamps.Add(lamp3);
            db.Lamps.Add(lamp4);
            db.Heaters.Add(heater1);
            db.TVs.Add(tv);
            db.SaveChanges();
        }
    }
}
