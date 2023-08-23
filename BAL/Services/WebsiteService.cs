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
    public class WebsiteService
    {
        public static List<WebsiteDTO> Get()
        {
            var data = DataAccessFactory.WebsiteData().Get();
            var cfg = new MapperConfiguration(c =>
            {

                c.CreateMap<Website, WebsiteDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<WebsiteDTO>>(data);
            return mapped;
        }

        public static WebsiteDTO Get(int id)
        {
            var data = DataAccessFactory.WebsiteData().Get();

            var cfg = new MapperConfiguration(c => {

                c.CreateMap<Website, WebsiteDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WebsiteDTO>(data);
            return mapped;
        }

        public static Website Create(WebsiteDTO website)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<WebsiteDTO, Website>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Website>(website);
            var data = DataAccessFactory.WebsiteData().Add(mapped);

            return data;

        }

        public static Website Update(WebsiteDTO website)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<WebsiteDTO, Website>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Website>(website);
            var data = DataAccessFactory.WebsiteData().Update(mapped);

            return data;

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.WebsiteData().Delete(id);

            return data;

        }
    }
}