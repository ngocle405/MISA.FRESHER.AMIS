using MISA.Fresher.Amis.Core.Entities;
using MISA.Fresher.Amis.Core.Exceptions;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MISA.Fresher.Amis.Core.Interfaces.Service;
using MISA.Fresher.Amis.Core.MisaAttribute;
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

        public int DeleteMultiRecord(List<string> listId)
        {
            var entities = _employeeRepository.DeleteMultiRecord(listId);
            return entities;
        }

        public string GetmployeeNewCode()
        {
            var entities=  _employeeRepository.GetEmployeeNewCode();
            return entities.ToString();
        }

        public object GetPaging(int limit, int pageIndex,string searchtext)
        {
            var entities = _employeeRepository.GetPaging(limit, pageIndex, searchtext);
            return entities;

        }
        protected override bool ValidateObjectCustom(Employee entity)
        {
            List<string> errorMsg = new List<string>();
            // Lấy ra trường muốn kiểm tra tồn tại
            var props = typeof(Employee).GetProperties();


            foreach (var prop in props)
            {
                var propertyValue = prop.GetValue(entity);
                // Lấy ra các propertyName
                var propNameDisplay = prop.Name;
                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    propNameDisplay = ((PropertyName)propertyNames[0]).Name;
                }
                var propertyDuplicate = prop.GetCustomAttributes(typeof(CheckDuplicate), true);
                if (propertyDuplicate.Length > 0)
                {
                    var checkDuplicate = _employeeRepository.CheckDuplicateProperty(entity.EmployeeId, prop.Name, propertyValue);
                    if (checkDuplicate != null)
                    {
                        errorMsg.Add($"{propNameDisplay} <{propertyValue}> đã tồn tại trong hệ thống vui lòng kiểm tra lại.");
                    }
                }
            }
            if (errorMsg.Count > 0)
            {
                throw new MISAResponseException(errorMsg);
            }
            return true;
        }
    }
}
