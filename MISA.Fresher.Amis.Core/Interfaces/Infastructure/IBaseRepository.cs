using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Interfaces.Infastructure
{
    public  interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// LTNgoc 17/12/2021
        /// </summary>
        /// <returns>ds bản ghi</returns>
        public IEnumerable<MISAEntity> Get();
        /// <summary>
        /// Lấy thông tin dữ liệu khách hàng
        /// LTNgoc 17/12/2021
        /// </summary>
        /// <returns> bản ghi theo id</returns>
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// lấy bản ghi theo id
        /// LTNgoc 17/12/2021
        /// </summary>
        /// <param name="tEntity"></param>
        /// <returns> số bản ghi ảnh hưởng</returns>
        public int Insert(MISAEntity entity);
        /// <summary>
        /// sửa thông tin 
        /// LTNgoc 17/12/2021
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns> số bản ghi ảnh hưởng</returns>
        public int Update(Guid entityId, MISAEntity entity);
        /// <summary>
        /// xóa khách hàng tiềm năng theo id
        /// LTNgoc 17/12/2021
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns> số bản ghi ảnh hưởng</returns>
        public int Delete(Guid entityId);

        /// <summary>
        /// Check trùng property
        /// </summary>
        /// <param name="propertyName">Tên</param>
        /// <param name="propertyValue">Giá trị</param>
        /// <returns>trả về đối tượng thì sai, k thì đúng</returns>
        /// CreateBy: NVChien(20/12/2021)
        public MISAEntity CheckDuplicateProperty(Guid entityId,string propertyName, object propertyValue);
    }
}
