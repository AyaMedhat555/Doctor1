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
    public class DoctorCrudController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorCrudController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GatAllDoctors()
        {
            var geners = await _context.Doctors.ToListAsync();

            return Ok(geners);
        }


        [HttpPost]
        public async Task<IActionResult> AddDoctorAsync([FromForm] DoctorDto dto)
        {

           
            var doctor = new Doctor
            {
                name = dto.name,
                age = dto.age,
                mail = dto.mail,
                NID = dto.NID,
                
                blood_group = dto.blood_group,
                mob_num = dto.mob_num,
                gender = dto.gender,
                password = dto.password,
                job = dto.job,
                address = dto.address,
                Degree = dto.Degree,
                specialization = dto.specialization

            };

            if (dto.Image != null)
            {
                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync(dataStream);
                doctor.Image = dataStream.ToArray();

            }

            await _context.AddAsync(doctor);
            _context.SaveChanges();

            return Ok(doctor);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] DoctorDto dto)
        {
            using var dataStream = new MemoryStream();
            await dto.Image.CopyToAsync(dataStream);

            var doctor = await _context.Doctors.SingleOrDefaultAsync(g => g.Id == id);

            if (doctor == null)
                return NotFound($"no doctor was found with ID :{id}");

            doctor.name = dto.name;
            doctor.age = dto.age;
            doctor.mail = dto.mail;
            doctor.NID = dto.NID;
            doctor.Image = dataStream.ToArray();
            doctor.blood_group = dto.blood_group;
            doctor.mob_num = dto.mob_num;
            doctor.gender = dto.gender;
            doctor.password = dto.password;
            doctor.job = dto.job;
            doctor.address = dto.address;
            doctor.Degree = dto.Degree;
            doctor.specialization = dto.specialization;
            _context.SaveChanges();

            return Ok(doctor);



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)

        {
            var doctor = await _context.Doctors.SingleOrDefaultAsync(d => d.Id == id);

            if (doctor == null)

                return NotFound($"no doctor was found with ID :{id}");

            _context.Remove(doctor);
            _context.SaveChanges();
            return Ok(doctor);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetdoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
                return NotFound("there is no doctor with this id");

            return Ok(doctor);
        }



        //public IHttpActionResult PutDoctor([FromUri] int id, [FromBody] DoctorDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (id != dto.Id)
        //    {
        //        return BadRequest("id is Wrong !!!!");
        //    }
        //    Db.Entry(dto).State = System.Data.Entity.EntityState.Modified;
        //    //
        //    //var olde1 = Db.Doctors.Find(id);
        //    //olde1.Name = dto.Name;
        //    //MIME Type
        //    //
        //    try
        //    {
        //        Db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        if (!DoctorExist(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return InternalServerError();
        //        }
        //    }
        //    //success
        //    return StatusCode(HttpStatusCode.NoContent);
        //    //
        //}




    }
}
