using Model.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Model.Model.Implementation
{

    public class TV : Device, ITV
    {
        public List<Channel> ChannelList { get; set; }

        public string CurrentChannel { get; set; }

        public TV(string type) : base(type)
        {
            ChannelList = new List<Channel>();
        }


        //public void ChangeChannel(int id)
        //{
        //    CurrentChannel.ChannelId = id;

        //}

        public void AddChannel(string name)
        {
            var length = ChannelList.Count();
            length++;
            Channel newChannel = new Channel(length, name);
            ChannelList.Add(newChannel);
        }

        public int Volume { get; set; }
        // List<Channel> IChannelable.ChannelList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public void SetCurrentChanel(string channelName)
        {
            //IEnumerable<Channel>channels = ChannelList.Where(ch => ch.ChannelName == channelName);
            foreach (Channel channel in ChannelList)
            {
                if (channel.ChannelName == channelName)
                {
                    CurrentChannel = channel.ChannelName;
                    channel.Current = true;
                }
                else
                {
                    channel.Current = false;
                }
            }
        }

        public void SetDefaultCurrentChannel()
        {
            foreach (Channel channel in ChannelList)
            {
                if (channel.Current)
                {
                    CurrentChannel = channel.ChannelName;
                    channel.Current = true;
                }
            }
        }

        void IChannelable.ChangeChannel(int id)
        {
            throw new NotImplementedException();
        }

        void IChannelable.AddChannel(string name)
        {
            throw new NotImplementedException();
        }


    }
} 
