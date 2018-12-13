using EHospital.Excel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHospital.Excel.BusinessLogic
{
    public interface IExcelService
    {
        /// <summary>
        /// Gets the collection of PatientInfos existing in the database.
        /// </summary>
        /// <returns> The collection of PatientView objects.</returns>
        IEnumerable<PatientInfo> GetPatients();

        Byte[] CreateReport();
    }
}
