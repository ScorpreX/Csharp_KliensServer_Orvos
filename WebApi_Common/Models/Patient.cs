using System.ComponentModel.DataAnnotations;
using WebApi_Common.Validation;

namespace WebApi_Common.Models
{
    public class Patient
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "A név kitöltése kötelező")]
        [PatientNameValidation]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "A lakcím kitöltése kötelező")]
        public string Address { get; set; }

        [Required(ErrorMessage ="A TAJ szám kitöltése kötelező!")]
        [SssnNumberValidation]
        public string SocialSecurityNumber { get; set;}

        [Required(ErrorMessage = "A tünetek mező kitöltése kötelező")]
        public string Symptom { get; set; }

        public string Diagnosis { get; set; }
        public DateTime RecordTime { get; set; }

        public override string ToString()
        {
            return $"{Name} - {SocialSecurityNumber} - {Symptom}";
        }
    }
}
