using EHospital.Excel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHospital.Patient.Data
{
    public interface IPatientData
    {
        IEnumerable<PatientInfo> GetPatients();
        PatientInfo GetPatient(int id);
        void AddPatient(PatientInfo patient);

        void Save();
    }
}
