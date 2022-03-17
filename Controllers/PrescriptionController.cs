using Doctor1.Context;
using Doctor1.Dtos;
using Doctor1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctor1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> AddPrescriptionAsync([FromForm] PrescriptionDto dto)
        {
            //var doctor = await _context.Doctors.FindAsync(dto.Doctor_Id);

            var NewPrescription = new Prescription
            {
                Medicine_Name = dto.Medicine_Name,
                Medicine_concentration = dto.Medicine_concentration,
                Instructions = dto.Instructions,
                MedicineType = dto.MedicineType,
                Dose = dto.Dose,
                Durarion = dto.Durarion,
                Prescription_Date = dto.Prescription_Date,
                re_appointement_date = dto.re_appointement_date,
                DoctorId = dto.Doctor_Id


            };

            await _context.Prescriptions.AddAsync(NewPrescription);
            _context.SaveChanges();
            return Ok(NewPrescription);

        }
        // get prescription by doctor id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            var prescription = _context.Prescriptions.Where(p => p.Id == id).Include(p => p.Doctor);
            //   var getp= prescription.Select(p => new PrescriptionDto
            //{
            //    Medicine_Name = p.Medicine_Name,
            //    Medicine_concentration = p.Medicine_concentration,
            //    Instructions = p.Instructions,
            //    MedicineType = p.MedicineType,
            //    Dose = p.Dose,
            //    Durarion = p.Durarion,
            //    Prescription_Date = p.Prescription_Date,
            //    re_appointement_date = p.re_appointement_date,
            //    Doctor_Id  = p.DoctorId

            //}); 
            //var prescriptionDto = prescription.

            if (prescription == null)
                return NotFound("there is no doctor with this id");

            return Ok(prescription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescriptionAsync(int id, [FromForm] PrescriptionDto dto)
        {


            var oldprescription = await _context.Prescriptions.SingleOrDefaultAsync(g => g.Id == id);

            if (oldprescription == null)
                return NotFound($"no prescription was found with ID :{id}");

            oldprescription.DoctorId = dto.Doctor_Id;
            oldprescription.Medicine_Name = dto.Medicine_Name;
            oldprescription.MedicineType = dto.MedicineType;
            oldprescription.Medicine_concentration = dto.Medicine_concentration;
            oldprescription.Dose = dto.Dose;
            oldprescription.Durarion = dto.Durarion;
            oldprescription.Instructions = dto.Instructions;
            oldprescription.Medicine_Name = dto.Medicine_Name;
            oldprescription.Prescription_Date = dto.Prescription_Date;
            oldprescription.re_appointement_date = dto.Prescription_Date;


            _context.SaveChanges();

            return Ok(oldprescription);



        }



        [HttpGet("GetAllPrescriptions")]

        public async Task<IActionResult> GetAllPrescriptions(byte doctor_id)
        {

            var All_Prescriptions = await _context.Prescriptions.Where(p => p.DoctorId == doctor_id).ToListAsync();

            return Ok(All_Prescriptions);

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionAsync(int id)

        {
            var prescription = await _context.Prescriptions.SingleOrDefaultAsync(P => P.Id == id);

            if (prescription == null)

                return NotFound($"no prescription was found with ID :{id}");

            _context.Remove(prescription);
            _context.SaveChanges();
            return Ok(prescription);

        }
    }
}
