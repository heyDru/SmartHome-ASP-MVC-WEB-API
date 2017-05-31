using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Model.Implementation
{
    public class Channel
    {

        public int ChannelId { get; set; }

        [Required]
        [StringLength(50)]
        public string ChannelName { get; set; }
        public bool Current { get; set; }

        public Channel(int channelId, string channelName)
        {
            ChannelId = channelId;
            ChannelName = channelName;
        }
    }
}
