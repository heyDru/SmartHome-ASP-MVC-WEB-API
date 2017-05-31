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
    class ChannelRepository : IChannelRepository
    {
        DevicesContext db;

        public ChannelRepository(DevicesContext context)
        {
            db = new DevicesContext();
        }

        public void Add(Channel channel)
        {
            db.Channels.Add(channel);
        }

        public Channel Get(int id)
        {
            return db.Channels.Find(id);
        }

        public ICollection<Channel> GetList()
        {
            return db.Channels.ToList();
        }

        public void Remove(int id)
        {
            Channel channel = db.Channels.FirstOrDefault(c => c.ChannelId == id);
            if (channel != null)
            {
                db.Channels.Remove(channel);
            }
        }

        public void Update(Channel channel)
        {
            db.Entry(channel).State = EntityState.Modified;
        }
    }
}
