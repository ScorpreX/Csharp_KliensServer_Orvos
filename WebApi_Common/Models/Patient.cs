using System;
using System.Text.RegularExpressions;

namespace WebApi_Common.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }   
        public string Address { get; set; }
        public string SocialSecurityNumber { get; set;}
        public string Symptom { get; set; }
        public DateTime RecordTime { get; set; }


        public override string ToString()
        {
            return $"{Name} - {Symptom}";
        }
    }
}
