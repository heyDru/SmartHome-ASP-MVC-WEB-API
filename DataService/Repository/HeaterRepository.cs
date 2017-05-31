using DataService.Repository.Interfaces;
using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public class HeaterRepository : IHeaterRepository
    {
        DevicesContext db;

        public HeaterRepository(DevicesContext context)
        {
            db = context;
        }

        public void Add(Heater heater)
        {
            db.Heaters.Add(heater);
        }

        public void Remove(int id)
        {
            Heater heater = db.Heaters.SingleOrDefault(p => p.Id == id);
            if (heater != null)
                db.Heaters.Remove(heater);
        }

        public Heater Get(int id)
        {
            return db.Heaters.Find(id);
        }

        public ICollection<Heater> GetList()
        {
            return db.Heaters.ToList();
        }

        public void Update(Heater heater)
        {
            db.Entry(heater).State = EntityState.Modified;
        }
    }
}
