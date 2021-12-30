using Microsoft.Extensions.Configuration;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MySqlConnector;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MISA.Fresher.Amis.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        //chỉ cho thằng con sử dụng
        protected  string _connectionStrings = string.Empty;
        protected string _className;
        protected string _emp;
        public BaseRepository(IConfiguration configuration)
        {
            _connectionStrings = configuration.GetConnectionString("CukCuk");
            _className = typeof(MISAEntity).Name;
           
        }
        public int Delete(Guid entityId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                //  var sql = $"delete from {_className} where {_className}Id = @entityId";
                var sql = $"Proc_Delete{_className}ById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_className}Id", entityId);
                var rowAffect = mySqlConnection.Execute(sql, param: parameters,commandType:CommandType.StoredProcedure);
                return rowAffect;
            }
                
        }
        //vitul để tk con dc phép ghi đè
        public IEnumerable<MISAEntity> Get()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                var customers = mySqlConnection.Query<MISAEntity>(sql: $"Proc_Get{_className}",commandType:CommandType.StoredProcedure);//empoyee

                return customers;
            }
        }
    

        public MISAEntity GetById(Guid entityId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                // var sql = $"SELECT * FROM {_className} WHERE {_className}Id = @entityId";
                var sql = $"Proc_Get{_className}ById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_className}Id", entityId);
                var rowAffect = mySqlConnection.QueryFirstOrDefault<MISAEntity>(sql, param: parameters,commandType:CommandType.StoredProcedure);
                return rowAffect;
            }
        }

        public  int Insert(MISAEntity entity)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                //var colums = "";
                //var columsParams = "";

                //DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                //                                                       // Lấy ra các property của đối tượng:                                               
                //var props = typeof(MISAEntity).GetProperties();
                ////lấy ra name của đối tượng
                //var className = typeof(MISAEntity).Name;

                ////duyệt từng property
                //foreach (var prop in props)
                //{
                //    // Lấy ra tên của property
                //    var propName = prop.Name;
                //    //lấy giá trị của property tương ứng đối tượng.
                //    var propValue = prop.GetValue(entity);
                //    //tạo ra mã khách hàng mới ngẫu nhiên
                //    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                //    {
                //        propValue = Guid.NewGuid();
                //    }
                //    //cập nhập chuỗi lệnh thêm mới và add tham số tương ứng.
                //    colums += $"{propName},";
                //    columsParams += $"@{propName},";
                //    parameters.Add($"@{propName}", propValue);

                //}
                ////thực hiện trừ đi kí tự (,) ở cuối cùng.
                //colums = colums.Substring(0, colums.Length - 1);
                //columsParams = columsParams.Substring(0, columsParams.Length - 1);
                ////

                //var sql = $"INSERT INTO {_className} ({colums}) VALUES ({columsParams})";

                var param = MappingType(entity);
                var sql = $"Proc_Insert{_className}";
                // thực thi thêm
                var rowAffect = mySqlConnection.Execute(sql, param: param,commandType:CommandType.StoredProcedure);
                return rowAffect;
            }
        }
        private DynamicParameters MappingType(MISAEntity entity)
        {
            //Lấy ra tất cả các property của class gọi đến
            var props = typeof(MISAEntity).GetProperties();
            // Tạo mới 1 đối tượng DynamicParameters để lưu trữ thông tin khi lặp qua các property
            var paramenters = new DynamicParameters();
            foreach (var prop in props)
            {
                // Lấy tên của property
                var propName = prop.Name;
                // Lấy ra giá trị của property
                var propValue = prop.GetValue(entity);
                // Lấy ra kiểu dữ liệu của property
                var propertyType = prop.PropertyType;
                if (propName == $"{_className}Id" && propertyType == typeof(Guid))//propName = NameId && proptype= guid
                {
                    paramenters.Add($"@{propName}", propValue, DbType.String);
                }
                else
                {
                    paramenters.Add($"@{propName}", propValue);
                }
            }
            return paramenters;
        }
        public int Update(Guid entityId, MISAEntity entity)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                //var colums = "";
                //var columsParams = "";
                //var sqlUpdate = "";
                //DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                //// Lấy ra các property của đối tượng:                                               
                //var props = typeof(MISAEntity).GetProperties();
                ////lấy ra name của đối tượng
                //var className = typeof(MISAEntity).Name;

                ////duyệt từng property
                //foreach (var prop in props)
                //{
                //    // Lấy ra tên của property
                //    var propName = prop.Name;
                //    //lấy giá trị của property tương ứng đối tượng.
                //    var propValue = prop.GetValue(entity);
                //    //đối chiếu mã khách hàng.
                //    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                //    {
                //        continue;
                //    }
                //    //cập nhập chuỗi lệnh thêm mới và add tham số tương ứng.

                //    colums = $"{propName}";
                //    columsParams = $"@{propName}";
                //    parameters.Add($"@{propName}", propValue);
                //    sqlUpdate += $"{colums} = {columsParams},";
                //}
                ////thực hiện trừ đi kí tự (,) ở cuối cùng.

                //sqlUpdate = sqlUpdate.Substring(0, sqlUpdate.Length - 1);
                //var sql = $"UPDATE {_className} SET {sqlUpdate} WHERE {className}Id = @entityId";
                DynamicParameters parameters = MappingType(entity);
                parameters.Add($"@entityId", entityId);//lấy id
                var sql = $"Proc_Update{_className}";
                // thực thi thêm
                var rowAffect = mySqlConnection.Execute(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return rowAffect;
            }
        }

        /// <summary>
        /// TH 1: Add - nếu mã nv (code) truyền vào == 1 mã nv đã tồn tại trong hệ thống và employeeId != employeeId mới tuyền vào(lấy dc id của bảng ý) sẽ báo lỗi 400.(t/m~)
        /// TH 2: Update - nếu mã nv (code) truyền vào == 1 mã nv tồn tại trong hệ thống và employeeId != employeeId đúng truyền vào (id của bảng ý) 
        /// sẽ không thỏa mãn cả 2 đki và loại bỏ điều kiện đó vì đk 2 bị loại bỏ.
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public MISAEntity CheckDuplicateProperty(Guid entityId,string propertyName, object propertyValue)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                //truyền vào id để kiểm tra mã đó của id đó, nếu khác mới kiểm tra
                var query = $"Select*from {_className} where {propertyName} = '{propertyValue}' and {_className}Id != '{entityId}'";
                var entity = mySqlConnection.QueryFirstOrDefault<MISAEntity>(query, commandType: CommandType.Text);
                return entity;
            }
                
        }
    }
}
