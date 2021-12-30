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
        /// <summary>
        /// LTNgoc
        /// Phân trang,tìm kiếm
        /// </summary>
        /// <param name="limit">số bản ghi trên 1 trang</param>
        /// <param name="pageIndex">số trang</param>
        /// <returns></returns>
        public IEnumerable<Department> GetPaging(int limit,int pageIndex,string searchText);
    }
}
