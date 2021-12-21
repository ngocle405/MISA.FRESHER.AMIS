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
    public class DepartmentRepository :BaseRepository<Department>, IDepartmentRepository
    {
        //string _connectionStrings = string.Empty;
        //string _className;
        public DepartmentRepository(IConfiguration configuration):base(configuration)
        {
            
        }

        //con gọi cha
        public override IEnumerable<Department> Get()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                var customers = mySqlConnection.Query<Department>(sql: $"SELECT * FROM {_className} limit 2");
                return customers;
            }
        }
       



    }
}
