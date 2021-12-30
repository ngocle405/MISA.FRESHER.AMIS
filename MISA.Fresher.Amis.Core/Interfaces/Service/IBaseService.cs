using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Interfaces.Service
{
    public interface IBaseService<MISAEntity>
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
        /// <returns> khách hàng theo id</returns>
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>số bản ghi thêm mới</returns>
        public int? Insert(MISAEntity entity);

        /// <summary>
        /// cập nhật 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>số bản ghi cập nhật</returns>
        public int? Update(MISAEntity entity,Guid entityId);
        /// <summary>
        /// xóa 1 bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Delete(Guid entityId);



    }
}
