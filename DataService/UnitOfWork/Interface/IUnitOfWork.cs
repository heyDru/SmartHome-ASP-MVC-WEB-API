using DataService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ILampRepository Lamps { get; }
        IHeaterRepository Heaters { get; }
        ITVRepository TVs { get; }
        IChannelRepository Channels { get; }
        IDeviceTypeRepository DeviceTypes { get; }
        void Save();
    }
}
