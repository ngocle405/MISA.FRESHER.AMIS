using MISA.Fresher.Amis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Interfaces.Infastructure
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        /// <summary>
        /// CreateBy:   LTNgoc (22/12/2021)
        /// Phân trang cho Employee
        /// </summary>
        /// <param name="limit">số lượng bản ghi trên 1 trang</param>
        /// <param name="pageIndex">số trang </param>
        /// <param name="searchtext">từ khóa tìm kiếm</param>
        /// <returns>danh sách tìm kiếm</returns>
        object GetPaging(int limit, int pageIndex, string searchtext);
        /// <summary>
        /// CreateBy:   LTNgoc (22/12/2021)
        /// tạo mã nhân viên mới ngẫu nhiên.
        /// </summary>
        /// <returns>1 mã nhân viên mới</returns>
        string GetEmployeeNewCode();


        /// <summary>
        /// xóa nhiều
        ///  CreateBy:   LTNgoc (22/12/2021)
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        int DeleteMultiRecord(List<string> listId);
    }
}
