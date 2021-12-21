using Microsoft.Extensions.Configuration;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MySqlConnector;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var sql = $"delete from {_className} where {_className}Id = @entityId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityId", entityId);
                var rowAffect = mySqlConnection.Execute(sql, param: parameters);
                return rowAffect;
            }
                
        }
        //vitul để tk con dc phép ghi đè
        public virtual IEnumerable<MISAEntity> Get()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                var customers = mySqlConnection.Query<MISAEntity>(sql: $"SELECT * FROM {_className}");//empoyee

                return customers;
            }
        }
    

        public MISAEntity GetById(Guid entityId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                var sql = $"SELECT * FROM {_className} WHERE {_className}Id = @entityId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityId", entityId);
                var rowAffect = mySqlConnection.QueryFirstOrDefault<MISAEntity>(sql, param: parameters);
                return rowAffect;
            }
        }

        public  int Insert(MISAEntity entity)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                var colums = "";
                var columsParams = "";

                DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                                                                       // Lấy ra các property của đối tượng:                                               
                var props = typeof(MISAEntity).GetProperties();
                //lấy ra name của đối tượng
                var className = typeof(MISAEntity).Name;

                //duyệt từng property
                foreach (var prop in props)
                {
                    // Lấy ra tên của property
                    var propName = prop.Name;
                    //lấy giá trị của property tương ứng đối tượng.
                    var propValue = prop.GetValue(entity);
                    //tạo ra mã khách hàng mới ngẫu nhiên
                    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                    }
                    //cập nhập chuỗi lệnh thêm mới và add tham số tương ứng.
                    colums += $"{propName},";
                    columsParams += $"@{propName},";
                    parameters.Add($"@{propName}", propValue);

                }
                //thực hiện trừ đi kí tự (,) ở cuối cùng.
                colums = colums.Substring(0, colums.Length - 1);
                columsParams = columsParams.Substring(0, columsParams.Length - 1);
                //

                var sql = $"INSERT INTO {_className} ({colums}) VALUES ({columsParams})";
                // thực thi thêm
                var rowAffect = mySqlConnection.Execute(sql, param: parameters);
                return rowAffect;
            }
        }

        public int Update(Guid entityId, MISAEntity entity)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                var colums = "";
                var columsParams = "";
                var sqlUpdate = "";
                DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                // Lấy ra các property của đối tượng:                                               
                var props = typeof(MISAEntity).GetProperties();
                //lấy ra name của đối tượng
                var className = typeof(MISAEntity).Name;

                //duyệt từng property
                foreach (var prop in props)
                {
                    // Lấy ra tên của property
                    var propName = prop.Name;
                    //lấy giá trị của property tương ứng đối tượng.
                    var propValue = prop.GetValue(entity);
                    //đối chiếu mã khách hàng.
                    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        continue;
                    }
                    //cập nhập chuỗi lệnh thêm mới và add tham số tương ứng.

                    colums = $"{propName}";
                    columsParams = $"@{propName}";
                    parameters.Add($"@{propName}", propValue);
                    sqlUpdate += $"{colums} = {columsParams},";
                }
                //thực hiện trừ đi kí tự (,) ở cuối cùng.

                sqlUpdate = sqlUpdate.Substring(0, sqlUpdate.Length - 1);
                var sql = $"UPDATE {_className} SET {sqlUpdate} WHERE {className}Id = @entityId";
                parameters.Add($"@entityId", entityId);//lấy id
                // thực thi thêm
                var rowAffect = mySqlConnection.Execute(sql, param: parameters, commandType: System.Data.CommandType.Text);
                return rowAffect;
            }
        }
    }
}
