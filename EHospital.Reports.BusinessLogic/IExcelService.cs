using EHospital.Reports.Model;
using System;
using System.Collections.Generic;

namespace EHospital.Reports.BusinessLogic
{
    public interface IExcelService
    {
        /// <summary>
        /// Gets the collection of PatientInfos existing in the database.
        /// </summary>
        /// <returns> The collection of PatientView objects.</returns>
        IEnumerable<PatientInfo> GetPatients();

        /// <summary>
        /// Creates EXCEL file containing all entries in Database
        /// </summary>
        /// <returns>EXCEL File as Byte Array</returns>
        Byte[] CreateReport();
    }
}
