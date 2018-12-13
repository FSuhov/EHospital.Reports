using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHospital.Excel.BusinessLogic;
using EHospital.Excel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.Excel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private IExcelService _service;

        public ExcelController(IExcelService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PatientInfo> patients = _service.GetPatients();
            Response.Clear();
            return Ok(patients);
        }

        
        [HttpGet("report")]
        public FileResult GetReport()
        {
            Byte[] data = _service.CreateReport();
            string fileType = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";
            string fileName = "ExcelReport.xlsx";
            Response.ContentType = "application/vnd.openxmlformat-officedocument.spreadsheetml.sheet";

            return File(data, fileType, fileName);
        }
    }

    
}