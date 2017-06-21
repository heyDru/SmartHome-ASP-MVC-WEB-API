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
    public class TVRepository : ITVRepository
    {
        DevicesContext db;
        public TVRepository(DevicesContext context)
        {
            db = context;
        }

        public void Add(TV tv)
        {
            Channel ch = db.Channels.FirstOrDefault();

            tv.CurrentChannel = ch;
            db.TVs.Add(tv);
        }

        public ICollection<TV> GetList()
        {
            return db.TVs.Include(t => t.CurrentChannel).ToList();
        }

        public TV Get(int id)
        {

            TV tv = db.TVs
              .Include(t => t.CurrentChannel)
              .Include(t=>t.Type)
              .SingleOrDefault(t => t.Id == id);

            return tv;
        }

        public void Remove(int id)
        {
            TV tv = db.TVs.FirstOrDefault(t => t.Id == id);
            if (tv != null)
            {
                db.TVs.Remove(tv);
            }
        }

        public void Switch()
        {
            throw new NotImplementedException();
        }

        public void Update(TV tv)
        {
            TV tvNew = db.TVs
                .Include(t => t.CurrentChannel)
                .SingleOrDefault(t => t.Id == tv.Id);

            Channel ch = db.Channels
                .FirstOrDefault(c => c.ChannelId == tv.CurrentChannel.ChannelId);

            tvNew.Name = tv.Name;
            tvNew.Volume = tv.Volume;
            tvNew.TurnOn = tv.TurnOn;
            tvNew.Consumption = tv.Consumption;
            tvNew.CurrentChannel = ch;
        }


    }
}
