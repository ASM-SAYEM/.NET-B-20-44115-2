using AutoMapper;
using BAL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.Services
{
    public class OTPresetService
    {
        public static List<OTPresetDTO> Get()
        {
            var data = DataAccessFactory.OTPresetData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OTPreset, OTPresetDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OTPresetDTO>>(data);

            return mapped;
        }

        public static OTPresetDTO Get(string otp)
        {
            var data = DataAccessFactory.OTPresetData().Get(otp);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OTPreset, OTPresetDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OTPresetDTO>(data);

            return mapped;


        }

        public static bool Create(OTPresetDTO member)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OTPresetDTO, OTPreset>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OTPreset>(member);

            return DataAccessFactory.OTPresetData().Add(mapped);
        }

        public static bool Update(OTPresetDTO member)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OTPresetDTO, OTPreset>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OTPreset>(member);
            return DataAccessFactory.OTPresetData().Update(mapped);
        }

        public static bool Delete(string otp)
        {
            return DataAccessFactory.OTPresetData().Delete(otp);
        }

    }
}