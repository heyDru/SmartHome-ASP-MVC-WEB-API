using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model.Implementation
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public bool Current { get; set; }

        public Channel(int channelId, string channelName)
        {
            ChannelId = channelId;
            ChannelName = channelName;
        }
    }
}
