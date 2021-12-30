using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Enums
{
    public enum Gender
    {
        /// <summary>
        /// Nữ
        /// </summary>
        Male = 1,
        /// <summary>
        /// Nam
        /// </summary>
        Female = 0,
        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }
    public enum Status
    {
        /// <summary>
        /// Lỗi validate không hợp lệ
        /// </summary>
        BadRequestError = 400,
        /// <summary>
        /// Lỗi server
        /// </summary>
        ServerError = 500
    }
}

