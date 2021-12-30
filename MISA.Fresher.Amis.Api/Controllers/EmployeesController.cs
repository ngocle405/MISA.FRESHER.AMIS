using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Amis.Core.Entities;
using MISA.Fresher.Amis.Core.Interfaces.Infastructure;
using MISA.Fresher.Amis.Core.Interfaces.Service;
using MISA.Fresher.Amis.Core.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class EmployeesController : MISABaseController<Employee>
    {
        // IEmployeeService _employeeservice;
        //iemployeerepository _employeerepository;

        public EmployeesController(IBaseService<Employee> baseService, IEmployeeService employeeService) : base(baseService)
        {
            _baseService = employeeService; //tương đương 

            //_baseRepository = employeeRepository;
            // _employeeService = employeeService;
            // _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// //ép kiểu _baseservice về đối tượng EmployeeServiceObject
        /// </summary>
        protected EmployeeService EmployeeServiceObject
        {
            //ép kiểu base service về EmployeeServiceObject
            get
            {
                return (EmployeeService)_baseService;
            }
        }
        [HttpGet("Paging")]
        public IActionResult GetPaging(int limit, int pageIndex, string searchtext)
        {
            var entities = EmployeeServiceObject.GetPaging(limit, pageIndex, searchtext);
            return Ok(entities);
        }
        [HttpGet("EmployeeNewCode")]
        public IActionResult GetEmployeeNewCode()
        {
            var emp = EmployeeServiceObject.GetmployeeNewCode();
            return Ok(emp);
        }
        [HttpPost("DeleteList")]
        public IActionResult DeleteMulti([FromBody] List<string> listId)
        {
            var result = EmployeeServiceObject.DeleteMultiRecord(listId);		

            return StatusCode(200, result);
        }
        [HttpGet("Export")]
        public IActionResult Export()
        {
            var result = EmployeeServiceObject.Get();
            var stream = new MemoryStream();

            //Format Ctrl+A -> Home -> Format -> Column(with, height)


            ////Format Ctrl+A -> Home -> Format -> Column(with, height)

            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\MiSA.Fresher.Amis.Core\ExcelTemplate\Danh_sach_nhan_vien.xlsx"));
            FileInfo existingFile = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                // đổ dữ liệu vào sheet

                int rowId = 4;
                int stt = 1;
                foreach (var row in result)
                {
                    sheet.Cells[rowId, 1].AutoFitColumns(10, 10);
                    for (int i = 1; i <= 9; i++)
                    {
                        // Thêm border cho cột
                        sheet.Cells[rowId, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        // Thêm width vs height cho cột
                        sheet.Cells[rowId, i + 1].AutoFitColumns(20, 20);
                        sheet.Cells[rowId, i + 1].Merge = true;
                    }
                    sheet.Cells[rowId, 1].Value = stt;
                    sheet.Cells[rowId, 2].Value = row.EmployeeCode;
                    sheet.Cells[rowId, 3].Value = row.EmployeeName;
                    sheet.Cells[rowId, 4].Value = row.GenderName;
                    sheet.Cells[rowId, 5].Value = row.DateOfBirth;
                    sheet.Cells[rowId, 6].Value = row.EmployeePosition;
                    sheet.Cells[rowId, 7].Value = row.DepartmentName;
                    sheet.Cells[rowId, 8].Value = row.BankAccountNumber;
                    sheet.Cells[rowId, 9].Value = row.BankName;
                    stt++;
                    rowId++;
                }
                stream = new MemoryStream(package.GetAsByteArray());
            }
            stream.Position = 0;
            var fileName = $"DanhSachNhanVien_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);

        }
    }
}