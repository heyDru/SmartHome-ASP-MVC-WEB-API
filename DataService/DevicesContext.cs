namespace DataService
{
    using Models.Model.Implementation;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DataService.Initializers;

    public class DevicesContext : DbContext
    {

        public DevicesContext()
            : base("name=DevicesContext")
        {
            Database.SetInitializer<DevicesContext>(new DevicesDropCreatebInitializer());
        }

        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Lamp> Lamps { get; set; }
        public virtual DbSet<Heater> Heaters{ get; set; }
        public virtual DbSet<TV> TVs{ get; set; }
        public virtual DbSet<Channel> Channels{ get; set; }
    }

}