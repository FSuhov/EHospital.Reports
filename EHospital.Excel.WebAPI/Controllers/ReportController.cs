using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHospital.Reports.BusinessLogic;
using EHospital.Reports.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.Reports.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IExcelService _service;

        public ReportController(IExcelService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles request GET api/Report/patients.
        /// Retrieves all entries of PatientInfo from Database.
        /// Left here for testing purposes only, i.e. just to understand does controller works
        /// even in case it does not load report properly.
        /// </summary>
        /// <returns>Ok with Collection of PatientInfo objects.</returns>
        [HttpGet("patients")]
        public IActionResult Get()
        {
            IEnumerable<PatientInfo> patients = _service.GetPatients();
            Response.Clear();
            return Ok(patients);
        }

        /// <summary>
        /// Handles request GET api/Report/excel.
        /// Generates excel file with all entries of Patients from the database.
        /// Transfer it to user as byte array, giving the opportunity to load excel file.
        /// </summary>
        /// <returns>Excel file as byte array.</returns>
        [HttpGet("excel")]
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