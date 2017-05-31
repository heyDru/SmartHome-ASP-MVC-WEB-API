using DataService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Model.Implementation;
using System.Data.Entity;

namespace DataService.Repository
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        DevicesContext db;

        public DeviceTypeRepository(DevicesContext context)
        {
            db = context;
        }

        public void Add(DeviceType deviceType)
        {
            db.DeviceTypes.Add(deviceType);
        }

        public void Remove(int id)
        {
            DeviceType deviceType = db.DeviceTypes.SingleOrDefault(p => p.Id == id);
            if (deviceType != null)
                db.DeviceTypes.Remove(deviceType);
        }

        public DeviceType Get(int id)
        {
            return db.DeviceTypes.Find(id);
        }

        public ICollection<DeviceType> GetList()
        {
            return db.DeviceTypes.ToList();
        }

        public void Switch()
        {
            throw new NotImplementedException();
        }

        public void Update(DeviceType deviceType)
        {
            db.Entry(deviceType).State = EntityState.Modified;
        }
    }
}
