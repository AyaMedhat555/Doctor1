using Doctor1.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctor1.Context
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasBaseType<User>();

            

            //modelBuilder.Entity<Prescription>()
            //    .HasOne(D => D.Doctor)
            //    .WithMany(D => D.Prescriptions)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade)
            //    ;
        }
        
    }
}
