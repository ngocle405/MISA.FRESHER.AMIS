using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MISA.Fresher.Amis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MISABaseController<MISAEntity> : ControllerBase
    {
        //interface chỉ tạo được các
        IBaseRepository<MISAEntity> _baseRepository ;
        IBaseService<MISAEntity> _baseService;
        public MISABaseController(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        /// <summary>
        /// lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseRepository.Get();
           
            return Ok(entities);
        }
        /// <summary>
        /// createBy:Lê thanh Ngọc (21/12/2021)
        /// </summary>
        /// <param name="entityId">entityId</param>
        /// <returns>1 obj  được tìm </returns>
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            var entities=_baseRepository.GetById(entityId);
            return Ok(entities);
        }
        /// <summary>
        /// createBy:Lê thanh Ngọc (21/12/2021)
        /// thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">1 object entity</param>
        /// <returns>1 obj đc thêm</returns>
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var entities = _baseService.Insert(entity);
            return StatusCode(201, entities);
            //try
            //{
            //}
            //catch (Exception ex)
            //{

            //    var result = new
            //    {
            //        devMsg = ex.Message,
            //        useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
            //        data = DBNull.Value,
            //        moreInfo = ""
            //    };
            //    return StatusCode(500, result);
            //}
        }


        /// <summary>
        /// createBy:Lê thanh Ngọc (21/12/2021)
        /// Update dữ liệu
        /// </summary>
        /// <param name="entityId">entityid</param>
        /// <param name="entity">1 obj </param>
        /// <returns>obj được update</returns>
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId,MISAEntity entity)
        {
            try
            {
                var entities = _baseService.Update(entity,entityId);
                return StatusCode(201, entities);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// createBy:Lê thanh Ngọc (21/12/2021)
        /// Xóa bỏ dữ liệu
        /// 
        /// </summary>
        /// <param name="entityId">entityId</param>
        /// <returns>null</returns>
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var entities = _baseRepository.Delete(entityId);
                return StatusCode(201, entities);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }
    }
}
