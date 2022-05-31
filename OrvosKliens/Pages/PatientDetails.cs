using Microsoft.AspNetCore.Components;
using WebApi_Common.Models;

namespace OrvosKliens.Pages
{
    public partial class PatientDetails
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        public Patient Patient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Patient = await HttpClient.GetFromJsonAsync<Patient>(HttpClient.BaseAddress + $"/patient/{Id}");
            await base.OnInitializedAsync();
        }

        private async Task ModifyPatient()
        {
            await HttpClient.PutAsJsonAsync<Patient>(HttpClient.BaseAddress + $"/patient", Patient);
            NavigationManager.NavigateTo("/patients");
        }
    }
}
