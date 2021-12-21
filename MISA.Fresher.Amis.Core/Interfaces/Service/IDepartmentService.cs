using MISA.Fresher.Amis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Interfaces.Service
{
    public interface IDepartmentService:IBaseService<Department>
    {
        public IEnumerable<Department> GetPaging(int limit,int pageIndex);
    }
}
