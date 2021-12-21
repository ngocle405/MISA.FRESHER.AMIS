using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Interfaces.Infastructure
{
    public  interface IBaseRepository<MISAEntity>
    {
        public IEnumerable<MISAEntity> Get();
        /// <summary>
        /// Lấy thông tin dữ liệu khách hàng
        /// Lê Thanh Ngọc 17/12/2021
        /// </summary>
        /// <returns> khách hàng theo id</returns>
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// tạo mới khách hàng tiềm năng
        /// Lê Thanh Ngọc 17/12/2021
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns> số bản ghi ảnh hưởng</returns>
        public int Insert(MISAEntity entity);
        /// <summary>
        /// sửa thông tin 
        /// Lê Thanh Ngọc 17/12/2021
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns> số bản ghi ảnh hưởng</returns>
        public int Update(Guid entityId, MISAEntity entity);
        /// <summary>
        /// xóa khách hàng tiềm năng theo id
        /// Lê Thanh Ngọc 17/12/2021
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns> số bản ghi ảnh hưởng</returns>
        public int Delete(Guid entityId);
    }
}
