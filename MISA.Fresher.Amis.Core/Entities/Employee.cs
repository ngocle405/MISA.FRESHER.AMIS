using MISA.Fresher.Amis.Core.MisaAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Fresher.Amis.Core.Enums;

namespace MISA.Fresher.Amis.Core.Entities
{
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        [PrimaryKey]
        [NotEmpty]
        [PropertyName("ID nhân viên")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [NotEmpty]
        
        [PropertyName("Mã nhân viên")]
        [CheckDuplicate]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        [NotEmpty]
        [PropertyName("Tên nhân viên")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [CheckDate]
        [PropertyName("Ngày sinh")]
        //[NotEmpty]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Lấy ra giới tính dựa vào tên
        /// </summary>
        /// CreateBy: LENGOC(20/12/2021)
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case Gender.Male:
                        return "Nam";
                    case Gender.Female:
                        return "Nữ";
                    case Gender.Other:
                        return "Khác";
                    default: return null;
                }
            }

        }
        /// <summary>
        /// Phòng ban
        /// </summary>
        [PropertyName("phòng ban")]
        [NotEmpty]
        public Guid? DepartmentId { get; set; }

      
        public string DepartmentName { get; }
        /// <summary>
        /// số cmnt
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        [PropertyName("Ngày cấp")]
        [CheckDate]
      //  [NotEmpty]
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Vị trí
        /// </summary>
        public string EmployeePosition { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// tài khoản ngân hàng
        /// </summary>
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string BankProvinceName { get; set; }
       // [NotEmpty]
        [PropertyName("Điện thoại")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
