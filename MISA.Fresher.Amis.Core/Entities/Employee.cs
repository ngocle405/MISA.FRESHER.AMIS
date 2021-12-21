using MISA.Fresher.Amis.Core.MisaAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [NotEmpty]
        [PropertyName("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        [NotEmpty]
        [PropertyName("Tên nhân viên")]
        
        public string EmployeeName { get; set; }
        [NotEmpty]
        [PropertyName("Điện thoại")]
        //[CheckDuplicate]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        [NotEmpty]
        [PropertyName("Tên phòng ban")]
        public Guid DepartmentId { get; set; }
    }
}
