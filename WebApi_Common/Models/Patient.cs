using System;
using System.Text.RegularExpressions;

namespace WebApi_Common.Models
{
    public class Patient
    {
        private string _name;
        private string _description;
        private string _socialSecurityNumber;
        private string _symptom;


        public long Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(_name))
                {
                    if (Regex.IsMatch(_name, @"^[A-Za-z ]+$"))
                    {
                        _name = value;
                    }
                    else
                    {
                        throw new Exception("Namefield must contain alphabetical letters");
                    }
                }
                else
                {
                    throw new Exception("Namefield can't be empty or whitespace");
                }
            }
        } 
        public string Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(_description))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Description can't be empty or whitespace");
                }
            }
        }   
        public string Address { get; set; }

        public string SocialSecurityNumber
        {
            
                get => _socialSecurityNumber;
            
            set
            {
                if (Regex.IsMatch(_name, @"^\d{3} \d{3} \d{3}$"))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("SSN format is not correct");
                }
            }
        }

        public string Symptom
        {
            get => _symptom;
            set
            {
                if (!string.IsNullOrWhiteSpace(_symptom))
                {
                    _symptom = value;
                }
                else
                {
                    throw new Exception("Symptom can't be empty or whitespace");
                }
            }
        }


        public override string ToString()
        {
            return $"{Name} - {Symptom}";
        }
    }
}
