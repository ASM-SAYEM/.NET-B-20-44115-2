using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SrviceProviderService
    {
        public static List<SrviceProviderDTO> Get()
        {
            var data = DataAccessFactory.SrviceProviderData().Get();
            var mapper = MapperService<SrviceProvider, SrviceProviderDTO>.GetMapper();
            return mapper.Map<List<SrviceProviderDTO>>(data);
        }
        public static SrviceProviderDTO Get(int id)
        {
            var data = DataAccessFactory.SrviceProviderData().Get(id);
            var mapper = MapperService<SrviceProvider, SrviceProviderDTO>.GetMapper();
            return mapper.Map<SrviceProviderDTO>(data);
        }
        public static bool Create(SrviceProviderDTO SrviceProvider)
        {
            var mapper = MapperService<SrviceProviderDTO, SrviceProvider>.GetMapper();
            var mapped = mapper.Map<SrviceProvider>(SrviceProvider);
            return DataAccessFactory.SrviceProviderData().Create(mapped);

        }
        public static bool Update(SrviceProviderDTO SrviceProvider)
        {
            var mapper = MapperService<SrviceProviderDTO, SrviceProvider>.GetMapper();
            var mapped = mapper.Map<SrviceProvider>(SrviceProvider);
            return DataAccessFactory.SrviceProviderData().Update(mapped);

        }
        public static bool Delete(int id)
        {

            return DataAccessFactory.SrviceProviderData().Delete(id);

        }
    }
}
