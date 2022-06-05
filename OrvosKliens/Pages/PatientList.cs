using WebApi_Common.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace OrvosKliens.Pages
{
    public partial class PatientList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Patient[] PatientsToList { get; set; }

        private Patient[] _patients;

        private string _search { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _patients = await HttpClient.GetFromJsonAsync<Patient[]>("patient");
            _patients = _patients
                .OrderBy(p => p.RecordTime)
                .ToArray();

            UpdatePatientsToList(null);
            
            await base.OnInitializedAsync();   
        }

        private void UpdatePatientsToList(ChangeEventArgs? args)
        {
            if (args is not null)
            {
                _search = (string)args.Value;
            }
            else
            {
                _search = "";
            }

            PatientsToList = _patients.Where(p => p.Name.Contains(_search)).ToArray();
        }
    }
}
