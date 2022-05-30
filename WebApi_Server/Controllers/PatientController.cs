using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private Patient p = new Patient()
        {
            Name = "Kiss Zsiga",
            Address = "Biharbasznád, Jókai 9",
            Id = 1,
            SocialSecurityNumber = "45465465",
            Symptom = "tüdőembólia"
        };
    [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            var patients = PatientRepository.LoadPatients();
            patients.ToList().Add(p);
            return Ok(p);
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patients = PatientRepository.LoadPatients();

            var patient = patients.FirstOrDefault(x => x.Id == id);
            if (patient != null)
            {
                return Ok(patient);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Patient patient)
        {
            var patients = PatientRepository.LoadPatients().ToList();

            patient.Id = GetNewId(patients);
            patients.Add(patient);

            PatientRepository.SavePatients(patients);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Patient patient)
        {
            var patients = PatientRepository.LoadPatients().ToList();

            var patientToUpdate = patients.FirstOrDefault(p => p.Id == patient.Id);
            if (patientToUpdate != null)
            {
               //TODO

                PatientRepository.SavePatients(patients);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var patients = PatientRepository.LoadPatients().ToList();

            var patientToDelete = patients.FirstOrDefault(p => p.Id == id);
            if (patientToDelete != null)
            {
                patients.Remove(patientToDelete);

                PatientRepository.SavePatients(patients);
                return Ok();
            }

            return NotFound();
        }

        private long GetNewId(IEnumerable<Patient> patients)
        {
            long newId = 0;
            foreach (var patient in patients)
            {
                if (newId < patient.Id)
                {
                    newId = patient.Id;
                }
            }

            return newId + 1;
        }
    }
}
