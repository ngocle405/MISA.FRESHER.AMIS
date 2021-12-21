using MISA.Fresher.Amis.Core.MisaAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        [NotEmpty]
        public string DepartmentCode { get; set; }
        [NotEmpty]
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        
    }
}
