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
    public class LampRepository : ILampRepository
    {
        DevicesContext db;

        public LampRepository(DevicesContext context)
        {
            db = context;
        }

        public void Add(Lamp lamp)
        {
            db.Lamps.Add(lamp);
        }

        public void Remove(int id)
        {
            Lamp lamp= db.Lamps.SingleOrDefault(p => p.Id == id);
            if (lamp != null)
                db.Lamps.Remove(lamp);
        }

        public Lamp Get(int id)
        {
            return db.Lamps.Find(id);
        }

        public ICollection<Lamp> GetList()
        {
            return db.Lamps.ToList();
        }

        public void Switch()
        {
            throw new NotImplementedException();
        }

        public void Update(Lamp lamp)
        {
            db.Entry(lamp).State = EntityState.Modified;
        }
    }
}
