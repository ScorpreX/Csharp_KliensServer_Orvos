using WebApi_Common.Models;
using Microsoft.AspNetCore.Components;

namespace OrvosKliens.Pages
{
    public partial class PatientList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        public Patient[] Patients { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Patients = await HttpClient.GetFromJsonAsync<Patient[]>(HttpClient.BaseAddress + "/patient");
            await base.OnInitializedAsync();   
        }
    }
}
