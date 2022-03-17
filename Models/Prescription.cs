namespace Doctor1.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Medicine_Name { get; set; }
        public string Medicine_concentration { get; set; } // medicine Strength
        public string Instructions { get; set; }

        public string MedicineType { get; set; }

        public string Dose { get; set; }

        public string Durarion { get; set; }
        public DateTime Prescription_Date { get; set; }
        public DateTime re_appointement_date { get; set; }

        public virtual Doctor Doctor { get; set; } ///Navigational Property

       // [ForeignKey("Doctor_PrescriptionID_FK")]
        public int DoctorId { get; set; } ///FK

    }
}


//- patient: Patient
//- doctor_id: int

