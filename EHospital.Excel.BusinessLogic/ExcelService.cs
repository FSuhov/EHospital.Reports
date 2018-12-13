using EHospital.Patient.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using EHospital.Excel.Model;
using OfficeOpenXml;
using System.Reflection;
using Microsoft.AspNetCore.Hosting.Internal;

namespace EHospital.Excel.BusinessLogic
{
    public class ExcelService : IExcelService
    {
        private readonly IPatientData _data;


        public ExcelService(IPatientData data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets the collection of PatientInfos existing in the database.
        /// Left for testing puproses only.
        /// </summary>
        /// <returns> The collection of PatientView objects.</returns>
        public IEnumerable<PatientInfo> GetPatients()
        {
            IEnumerable<PatientInfo> patients = _data.GetPatients().Where(p => p.IsDeleted != true);

            return patients;
        }

        /// <summary>
        /// Generates Byte Array containing Excel File
        /// </summary>
        /// <returns>Byte Array</returns>
        public Byte[] CreateReport()
        {
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Patients");

            ws.Cells["A1"].Value = "EHospital - REPORTS";
            ws.Cells["B1"].Value = "Patients";
            ws.Cells["C1"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A3"].Value = "Patient ID";
            ws.Cells["B3"].Value = "Name";
            ws.Cells["C3"].Value = "Surname";
            ws.Cells["D3"].Value = "Country";
            ws.Cells["E3"].Value = "City";
            ws.Cells["F3"].Value = "Address";
            ws.Cells["G3"].Value = "Birthdate";
            ws.Cells["H3"].Value = "Phone";
            ws.Cells["I3"].Value = "Gender";
            ws.Cells["J3"].Value = "Email";

            IEnumerable<PatientInfo> patients = _data.GetPatients().Where(p => p.IsDeleted != true);

            int currentRow = 4;

            foreach (PatientInfo item in patients)
            {
                ws.Cells[$"A{currentRow}"].Value = item.Id;
                ws.Cells[string.Format("B{0}", currentRow)].Value = item.FirstName;
                ws.Cells[string.Format("C{0}", currentRow)].Value = item.LastName;
                ws.Cells[string.Format("D{0}", currentRow)].Value = item.Country;
                ws.Cells[string.Format("E{0}", currentRow)].Value = item.City;
                ws.Cells[string.Format("F{0}", currentRow)].Value = item.Address;
                ws.Cells[string.Format("G{0}", currentRow)].Value = item.BirthDate;
                ws.Cells[string.Format("H{0}", currentRow)].Value = item.Phone;
                ws.Cells[string.Format("I{0}", currentRow)].Value = item.Gender;
                ws.Cells[string.Format("J{0}", currentRow)].Value = item.Email;

                currentRow++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();

            Byte[] reportAsBytes = pck.GetAsByteArray();

            return reportAsBytes;
        }
    }
}
