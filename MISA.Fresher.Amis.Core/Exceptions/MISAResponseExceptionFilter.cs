using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MISA.Fresher.Amis.Core.Enums;
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
                    devMsg = MISA.Fresher.Amis.Core.Properties.Resources.BadRequestError,
                    useMsg = MISA.Fresher.Amis.Core.Properties.Resources.ExceptionError,
                    data = httpResponseException.Value,
                    moreInfo = ""
                };

                context.Result = new ObjectResult(result)
                {
                    StatusCode = (int)Status.BadRequestError
                };

                context.ExceptionHandled = true;
            }
            else if(context.Exception != null)
            {
                var result = new
                {
                    devMsg = MISA.Fresher.Amis.Core.Properties.Resources.ServerError,
                    useMsg = MISA.Fresher.Amis.Core.Properties.Resources.ExceptionError,
                    data = DBNull.Value,
                    moreInfo = ""
                };

                context.Result = new ObjectResult(result)
                {
                    StatusCode = (int)Status.ServerError
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
