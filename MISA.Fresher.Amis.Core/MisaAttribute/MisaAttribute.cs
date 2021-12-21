using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Core.MisaAttribute
{
    // dựng các attribute để bắt lỗi exceptions


    /// Attribute không cho phép NULL
    /// </summary>
    /// CreatedBy: Lê thanh ngọc(22/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty : Attribute
    {

    }
    /// Attribute đặt tên cho các property
    /// </summary>
    /// CreatedBy: Lê thanh ngọc(21/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyName : Attribute
    {
        public string Name { get; set; }
        public PropertyName(string name)
        {
            this.Name = name;
        }
    }
    /// <summary>
    /// Attribute kiểm tra độ dài của chuỗi
    /// </summary>
    /// CreatedBy: Lê thanh ngọc(21/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Length { get; set; }
        public MaxLength(int length)
        {
            this.Length = length;
        }
    }
}
