using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Fresher.Amis.Core.Entities;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
   
        /// <summary>
        /// Phân trang cho Employee
        /// </summary>
        /// <param name="limit">số lượng bản ghi trên 1 trang</param>
        /// <param name="pageIndex">số trang </param>
        /// <param name="searchtext">từ khóa tìm kiếm</param>
        /// <returns>danh sách tìm kiếm</returns>
        public object GetPaging(int limit, int pageIndex,string searchtext)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                //limit(pagesize) : tong so ban ghi trên 1 trang
                //pageIndex: số trang(vd trang 1)
                ////thực thi lấy dữ liệu db
                var sql = "Proc_GetEmployeePaging";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeFilter", searchtext);
                parameters.Add("@PageIndex", pageIndex);
                parameters.Add("@PageSize", limit);
                parameters.Add("@TotalRecord", direction:System.Data.ParameterDirection.Output);
                parameters.Add("@TotalPage", direction: System.Data.ParameterDirection.Output);
                var entities = mySqlConnection.Query<Employee>(sql,param:parameters,commandType:System.Data.CommandType.StoredProcedure);
                var totalRecord = parameters.Get<int>("@TotalRecord");
                var TotalPage = parameters.Get<int>("@TotalPage");

                return new
                {
                    totalRecord = totalRecord,
                    totalPage = TotalPage,
                    Data =entities
                };
            }
        }
        /// <summary>
        /// tạo mã nhân viên mới
        /// createBy:lê thanh Ngọc
        /// </summary>
        /// <returns>1 mã nhân viên mới</returns>
        public string GetEmployeeNewCode()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                mySqlConnection.Open();
                var sql = "Proc_GetNewEmployeeCode";
                var rowAffect = mySqlConnection.QueryFirstOrDefault<string>(sql, commandType: System.Data.CommandType.StoredProcedure);
                mySqlConnection.Close();
                return rowAffect.ToString();
            }
        }
        /// <summary>
        /// createBy:lê thanh Ngọc
        /// xóa nhiều
        /// </summary>
        /// <param name="listId">1 danh sách id cần xóa</param>
        /// <returns>null</returns>
        public int DeleteMultiRecord(List<string> listId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                DynamicParameters parameters = new DynamicParameters();
                //var ListEmployeeId = string.Empty;
                ////foreach (string id in listId)
                ////{
                ////    ListEmployeeId += id + ",";
                ////}
                parameters.Add("@listId", string.Join(',', listId));
                var sql = "Proc_DeleteMultipleRecordEmployee";
                var rowAffect = mySqlConnection.Execute(sql,param:parameters, commandType: System.Data.CommandType.StoredProcedure);
                var count = rowAffect;
                return rowAffect;
            }
        }


    }
}
