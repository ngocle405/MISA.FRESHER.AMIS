using MISA.Fresher.Amis.Core.Entities;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MISA.Fresher.Amis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IBaseRepository<Employee> baseRepository,IEmployeeRepository employeeRepository) : base(baseRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public object GetPaging(int limit, int pageIndex,string searchtext)
        {
            var entities = _employeeRepository.GetPaging(limit, pageIndex, searchtext);
            return entities;

        }
    }
}
