using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model.Interfaces
{
    public interface IChannelable
    {

        ICollection<Channel> ChannelList { get; set; }

        string CurrentChannel { get; set; }

        void AddChannel(string name);

        void SetDefaultCurrentChannel();

    }
}
