using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Exceptions
{
    public  class MISAResponseException:Exception
    {
        // bắt lỗi sử dụng Exception Handling Middleware .
        public MISAResponseException(object value = null) => (Value) = (value);
        public object Value { get; }
    }
}
