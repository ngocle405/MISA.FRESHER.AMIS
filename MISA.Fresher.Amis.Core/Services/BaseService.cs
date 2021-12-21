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
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity>  baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int? Insert(MISAEntity entity)
        {
            //validate chung cho BAse xử lý;
            var isValid = ValidateObject(entity);
            //validate đặc thù cho từng đối tượng.-> cho các service con tự xử lí
            if (isValid==true)
            {
                isValid = ValidateObjectCustom(entity);
                //valid hợp lệ thì đi tiếp ->
            }
            if(isValid == true)//đã hợp lệ
            {
                var entities = _baseRepository.Insert(entity);
                return entities;
            }
            return null;
        }

        public int Update(MISAEntity entity,Guid entityId )
        {
            var entities = _baseRepository.Update(entityId,entity);
            return entities;
        }
        /// <summary>
        /// CreateBy:lê thanh ngọc (17/12/2021)
        /// thực hiện validate chung
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - hợp lê;false - dữ liệu k hợp lệ</returns>
        bool ValidateObject(MISAEntity entity)
        {
            // tạo 1 List chứa lỗi
            List<string> errorMsg = new List<string>();

            //các thông tin bắt buộc nhập
            //1.kiểm tra tất cả các property của đối tượng.
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var prop in properties)
            {
                //var propName = prop.Name;
                //lấy giá trị
                var propValue = prop.GetValue(entity);
                //lấy tên 
                var propNameDisplay = prop.Name;
                
                //
                var propType = prop.PropertyType;

                // Lấy ra độ dài của kí tự của property
                var propertyMaxLength = prop.GetCustomAttributes(typeof(MaxLength), true);

                var propNotEmptys = prop.GetCustomAttributes(typeof(NotEmpty),true);//kiểm tra bên att notempty

                // Lấy ra các propertyName
                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                // Xem các property đó có có tồn tại PropertyName không
                if (propertyNames.Length > 0)
                {
                    // Thay đổi giá trị cũ của entity gán bằng PropertyName được đặt
                    propNameDisplay = ((PropertyName)propertyNames[0]).Name;
                }
                //2.xem các property đó có phải là prop được thiết lập bắt buộc nhập hay ko
                //nếu đc đặt attr NotEmptys
                if (propNotEmptys.Length >0 )
                {
                    //3.nếu thông tin bắt buộc nhập thì cảnh báo/đánh dấu trạng thái không hợp lệ.
                    //trim bỏ các khoảng cách 2 đầu
                    if (propValue == null || string.IsNullOrEmpty(propValue.ToString().Trim()))
                    {
                        errorMsg.Add($"Thông tin {propNameDisplay} không được phép để trống.");
                        //throw new Exception($"Thông tin {propNameDisplay} không được phép để trống.");
                    }
                }
                if (propertyMaxLength.Length > 0)
                {
                    var length = ((MaxLength)propertyMaxLength[0]).Length;
                    //3. nếu thông tin bắt buộc nhập hiển thị cảnh báo hoặc đánh giấu trang thái không hợp lệ
                    if (propValue != null && ((string)propValue).Trim().Length > length)
                    {
                        errorMsg.Add($"Thông tin {propNameDisplay} không được phép dài quá {length} kí tự.");
                        //throw new Exception($"Thông tin {propNameDisplay} không được phép dài quá {length} kí tự.");
                    }
                }
            }
            // bắt lỗi sử dụng Exception Handling Middleware .
            if (errorMsg.Count > 0)
            {
                throw new MISAResponseException(errorMsg);
            }
            return true;

        }
        bool ValidateObjectCustom(MISAEntity entity)
        {
            return true;
        }
    }
}
