using DataService.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Repository.Interfaces;
using DataService.Repository;

namespace DataService.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevicesContext _context;
        public UnitOfWork(DevicesContext context)
        {
            _context = context;
            Lamps = new LampRepository(_context);
            Heaters = new HeaterRepository(_context);
            TVs = new TVRepository(_context);
            Channels = new ChannelRepository(_context);
            DeviceTypes = new DeviceTypeRepository(_context);
        }

        public UnitOfWork()
        {
            _context = new DevicesContext();
            Lamps = new LampRepository(_context);
            Heaters = new HeaterRepository(_context);
            TVs = new TVRepository(_context);
            Channels = new ChannelRepository(_context);
            DeviceTypes = new DeviceTypeRepository(_context);
        }

        public ILampRepository Lamps { get; private set; }

        public IHeaterRepository Heaters { get; private set; }

        public ITVRepository TVs { get; private set; }

        public IChannelRepository Channels { get; private set; }

        public IDeviceTypeRepository DeviceTypes { get; private set; }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
