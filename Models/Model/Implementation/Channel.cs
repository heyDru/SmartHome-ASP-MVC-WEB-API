using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Model.Implementation
{
    public class Channel
    {
        [Required]
        public int ChannelId { get; set; }

        [Required]
        [StringLength(50)]
        public string ChannelName { get; set; }
    }
}
