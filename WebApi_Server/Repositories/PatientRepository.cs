using System.Text;
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
                using var stream  = new FileStream(_filename, FileMode.Open, FileAccess.Read);
                using var read = new StreamReader(stream, Encoding.UTF8);
                string rawData = read.ReadToEnd();

                var patients = JsonSerializer.Deserialize<IEnumerable<Patient>>(rawData);
                return patients;
            }

            return new List<Patient>();
        }

        public static void SavePatients(IEnumerable<Patient> patients)
        {
            var rawData = JsonSerializer.Serialize(patients);
            using var stream = new FileStream(_filename, FileMode.OpenOrCreate, FileAccess.Write);
            using var write = new StreamWriter(stream, Encoding.UTF8);

            write.WriteLine(rawData);
        }
    }
}
