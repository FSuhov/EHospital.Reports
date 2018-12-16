using EHospital.Reports.Model;
using System.Collections.Generic;

namespace EHospital.Reports.Data
{
    public interface IPatientData
    {
        IEnumerable<PatientInfo> GetPatients();
    }
}
