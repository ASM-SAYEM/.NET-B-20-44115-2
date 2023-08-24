using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo3<TYPE, ID, RET> : IRepo<TYPE, ID, RET>
    {
        TYPE SetOTP(string id, string otp);
    }
    
}
