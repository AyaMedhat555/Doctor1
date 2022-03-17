namespace Doctor1.Models
{
    public abstract class User
    {
  
       public int Id { get; set; }

       public string name { get; set; }

        public int age { get; set; }

        public string mail { get; set; }

        public string NID { get; set; }//national id

        public byte[]? Image { get; set; }
        public string blood_group { get; set; }
        public string mob_num { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
        public string job { get; set; }
        public string address { get; set; }
       

    }
}

