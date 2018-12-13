using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Mime;
using EHospital.Excel.Model;

namespace EHospital.Patient.Data
{
    public class PatientDataContext : DbContext, IPatientData
    {
        /// <summary>
        /// Initializes new instance of LibraryContext
        /// </summary>
        public PatientDataContext()
        { }

        /// <summary>
        /// Initializes new instance of LibraryContext using options passed on application launch
        /// in the file Startup.cs
        /// </summary>
        /// /// <param name="options"> An options for connecting to data source </param>
        public PatientDataContext(DbContextOptions<PatientDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInfo>()
                .ToTable("PatientInfo");
        }

        /// <summary>
        /// Gets or sets the collection of Patients using EF models
        /// </summary>
        public DbSet<PatientInfo> Patients { get; set; }

        /// <summary>
        /// Gets all Patients from database
        /// </summary>
        /// <returns>Collection of PatientInfos</returns>
        public IEnumerable<PatientInfo> GetPatients()
        {
            return Patients.ToList();
        }
        
        /// <summary>
        /// Saves changes in the collections
        /// Calls DbContext base SaveChanges Method
        /// </summary>
        public void Save()
        {
            this.SaveChanges();
        }
    }
}
