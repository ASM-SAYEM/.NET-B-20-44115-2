using AutoMapper;
using BAL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.Services
{
    public class ServiceProviderService
    {
        public static List<ServiceProviderDTO> Get()
        {
            var data = DataAccessFactory.ServiceProviderData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                //c.CreateMap<ClientDTO, Client>();
                c.CreateMap<ServiceProvider, ServiceProviderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ServiceProviderDTO>>(data);
            return mapped;
        }

        public static ServiceProviderDTO Get(int id)
        {
            var data = DataAccessFactory.ServiceProviderData().Get(id);

            var cfg = new MapperConfiguration(c => {
                // c.CreateMap<ServiceProviderDTO, ServiceProvider>();
                c.CreateMap<ServiceProvider, ServiceProviderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceProviderDTO>(data);
            return mapped;
        }

        public static ServiceProvider Create(ServiceProviderDTO serviceProvider)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceProviderDTO, ServiceProvider>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceProvider>(serviceProvider);
            var data = DataAccessFactory.ServiceProviderData().Add(mapped);

            return data;

        }

        public static ServiceProvider Update(ServiceProviderDTO serviceProvider)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ServiceProviderDTO, ServiceProvider>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ServiceProvider>(serviceProvider);
            var data = DataAccessFactory.ServiceProviderData().Update(mapped);

            return data;

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.ServiceProviderData().Delete(id);

            return data;

        }
    }
}