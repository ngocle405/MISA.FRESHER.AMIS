using MISA.Fresher.Amis.Core.Entities;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MISA.Fresher.Amis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        public DepartmentService(IBaseRepository<Department> baseRepository) : base(baseRepository)
        {
        }

        public IEnumerable<Department> GetPaging(int limit, int pageIndex,string searchText)
        {
            return null;
        }
        
    }
}
