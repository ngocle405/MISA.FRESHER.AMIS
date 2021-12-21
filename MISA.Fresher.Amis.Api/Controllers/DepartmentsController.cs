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
    public class DepartmentsController : MISABaseController<Department>
    {
        IDepartmentService _departmentService;
        IDepartmentRepository departmentRepository;
        //IBaseRepository<Department> _baseRepository;
        public DepartmentsController(
            IBaseRepository<Department> baseRepository, //lấy của tk cha
           //  IDepartmentRepository departmentRepository,//lấy của tk con config DI
            IBaseService<Department> baseService ,//lấy của cha
           IDepartmentService departmentService //lấy của con
            ):base(baseRepository, baseService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("Paging")]
        public IActionResult Paging(int limit,int pageIndex) 
        {
            return Ok(_departmentService.GetPaging(limit,pageIndex));
        }

    }
}
