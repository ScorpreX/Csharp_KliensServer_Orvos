using System.Text.Json;
using WebApi_Common.Models;

namespace WebApi_Server.Repositories
{
    public class PatientRepository
    {
        private const string _filename = "Patients.json";

        public static IEnumerable<Patient> LoadPatients()
        {
            if (File.Exists(_filename))
            {
                var rawData = File.ReadAllText(_filename);
                var patients = JsonSerializer.Deserialize<IEnumerable<Patient>>(rawData);
                return patients;
            }

            return new List<Patient>();
        }

        public static void SavePatients(IEnumerable<Patient> patients)
        {
            var rawData = JsonSerializer.Serialize(patients);
            File.WriteAllText(_filename, rawData);
        }
    }
}
