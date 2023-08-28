using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo2<CLASS, String, RET>
    {
         CLASS GetToken(String id);
    
}
}
