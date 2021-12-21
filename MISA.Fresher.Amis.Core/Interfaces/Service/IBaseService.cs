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
        public int Update(MISAEntity entity,Guid entityId);


    }
}
