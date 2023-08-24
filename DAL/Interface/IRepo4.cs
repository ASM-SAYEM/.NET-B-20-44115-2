using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo4<CLASS, ID, RES> : IRepo<CLASS, ID, RES>
    {
        CLASS Get(string UserName, string password);
        bool ChangePass(string UserName, string password, string newPassword);
        CLASS ForgetPass(string gmail);
        bool ResetPass(string UserName, string password);
    }
}
