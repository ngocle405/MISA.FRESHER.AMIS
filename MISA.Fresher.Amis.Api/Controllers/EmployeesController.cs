using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Amis.Core.Entities;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MISA.Fresher.Amis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class EmployeesController : MISABaseController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeesController(IBaseRepository<Employee> baseRepository, IBaseService<Employee> baseService,IEmployeeService employeeService) : base(baseRepository, baseService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("Paging")]
        public IActionResult GetPaging(int limit,int pageIndex,string searchtext)
        {
            var entities = _employeeService.GetPaging(limit, pageIndex, searchtext);
            return Ok(entities);
        }
    }
}
