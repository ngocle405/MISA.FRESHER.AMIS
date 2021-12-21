using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Exceptions
{
    public class MISAResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        // bắt lỗi sử dụng Exception Handling Middleware .
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.Exception is MISAResponseException httpResponseException)
            {
                var result = new
                {
                    devMsg = "Dữ liệu đầu vào không hợp lệ.",
                    useMsg = MISA.Fresher.Amis.Core.Properties.Resources.ExceptionError,
                    data = httpResponseException.Value,
                    moreInfo = ""
                };

                context.Result = new ObjectResult(result)
                {
                    StatusCode = 400
                };

                context.ExceptionHandled = true;
            }
            else if(context.Exception != null)
            {
                var result = new
                {
                    devMsg = "",
                    useMsg = MISA.Fresher.Amis.Core.Properties.Resources.ExceptionError,
                    data = DBNull.Value,
                    moreInfo = ""
                };

                context.Result = new ObjectResult(result)
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
