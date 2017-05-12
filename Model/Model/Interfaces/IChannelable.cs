using Model.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Interfaces
{
    public interface IChannelable
    {
        void ChangeChannel(int id);

        List<Channel> ChannelList { get; set; }

        string CurrentChannel { get; set; }

        void AddChannel(string name);

        void SetDefaultCurrentChannel();

    }
}
