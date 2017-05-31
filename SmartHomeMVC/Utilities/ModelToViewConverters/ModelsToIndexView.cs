using AutoMapper;
using DataService.UnitOfWork.Interface;
using Models.Model.Implementation;
using SmartHomeMVC.Models.ViewModels;
using SmartHomeMVC.Models.ViewModels.IndexViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeMVC.Utilities.ModelToViewConverters
{
    public class ModelsToIndexView
    {
        public ModelsToIndexView()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Heater, HeaterIndexViewModel>();
                cfg.CreateMap<TV, TVIndexViewModel>();
                cfg.CreateMap<Lamp, LampIndexViewModel>();
                cfg.CreateMap<DeviceType, DeviceTypeIndexViewModel>();
                cfg.CreateMap<Channel, ChannelViewModel>();
            });
        }

        public IndexViewModel GetIndexViewModel (ICollection<Lamp> lamps, ICollection<Heater> heaters, ICollection<TV> tvs, ICollection<DeviceType> deviceTypes)
        {

            var heatersViewModel = Mapper.Map<IEnumerable<Heater>, List<HeaterIndexViewModel>>(heaters);

            var tvsViewModel = Mapper.Map<IEnumerable<TV>, List<TVIndexViewModel>>(tvs);

            var lampsViewModel = Mapper.Map<IEnumerable<Lamp>, List<LampIndexViewModel>>(lamps);

            var devicesTypesViewModel = Mapper.Map<IEnumerable<DeviceType>, List<DeviceTypeIndexViewModel>>(deviceTypes);
            IndexViewModel model = new IndexViewModel
            {
                Lamps = lampsViewModel,
                Heaters = heatersViewModel,
                TVs = tvsViewModel,
                DeviceTypes = devicesTypesViewModel
            };
            return model;
        }

        public LampIndexViewModel GetLampIndexViewModel(Lamp lamp)
        {
            var lampIndexViewModel = Mapper.Map<Lamp, LampIndexViewModel>(lamp);
            return lampIndexViewModel;
        }

        public HeaterIndexViewModel GetHeaterViewModel(Heater heater)
        {
            var heaterIndexViewModel = Mapper.Map<Heater, HeaterIndexViewModel>(heater);
            return heaterIndexViewModel;
        }

        public TVIndexViewModel GetTVViewModel(TV tv)
        {
            var tvIndexViewModel = Mapper.Map<TV, TVIndexViewModel>(tv);
            return tvIndexViewModel;
        }

        public ChannelViewModel GetChannelViewModel(Channel channel)
        {
            var channelViewModel = Mapper.Map<Channel, ChannelViewModel>(channel);
            return channelViewModel;
        }
        
        public IEnumerable<ChannelViewModel> GetChannelViewModelList(ICollection<Channel> channels)
        {
            var channelsViewModel = Mapper.Map<IEnumerable<Channel>, List<ChannelViewModel>>(channels);

            return channelsViewModel;
        }


    }
}