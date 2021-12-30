using MISA.Fresher.Amis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Interfaces.Service
{
    public interface IEmployeeService :IBaseService<Employee>
    {
        /// <summary>
        /// Phân trang service
        /// CreateBy:LTNgoc (25/12/2021)
        /// </summary>
        /// <param name="limit">số bản ghi trên 1 trang</param>
        /// <param name="pageIndex">số trang </param>
        /// <param name="searchtext">từ khóa tk</param>
        /// <returns></returns>
        public object GetPaging(int limit, int pageIndex,string searchtext);

        /// <summary>
        /// tạo 1 mã nhân viên mới
        ///  CreateBy:LTNgoc (25/12/2021)
        /// </summary>
        /// <returns></returns>
        public string GetmployeeNewCode();

        /// <summary>
        /// xÓA NHIỀU BẢN GHI
        ///  CreateBy:LTNgoc (25/12/2021)
        /// </summary>
        /// <param name="listId">1 LIST ID</param>
        /// <returns></returns>
        public int DeleteMultiRecord(List<string> listId);
    }
}
