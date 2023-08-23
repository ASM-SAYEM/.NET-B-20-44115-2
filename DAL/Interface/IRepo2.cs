using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo2<CLASS,ID,RES> : IRepo<CLASS,ID,RES>
    {
        CLASS GetPercentage(double percentage);
    }
}
