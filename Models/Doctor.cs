namespace Doctor1.Models
{
    public class Doctor:User
    {

       // public int Id { get; set; }
        public string Degree { get; set; }
        public string specialization  { get; set; }

       // public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>(); //collection navigation property


    }
}

//- department: Department
//- patients:Patient[] 
//- dodtor_notes: String