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

        private string _statusClass = "";
        private string _statusMessage = "";

        protected override async Task OnInitializedAsync()
        {
            Patient = await HttpClient.GetFromJsonAsync<Patient>($"patient/{Id}");
            await base.OnInitializedAsync();
        }

        private async Task ModifyPatient()
        {
            _statusClass = "";
            _statusMessage = "";
            await HttpClient.PutAsJsonAsync<Patient>($"patient", Patient);
            _statusClass = "alert-info";
            _statusMessage = "Adatok sikeresen módosítva!";
        }

        private void InvalidSubmit()
        {
            _statusClass = "alert-danger";
            _statusMessage = "Hibás adatok vannak megadva!";
        }

        private async Task DeletePatient()
        {
            await HttpClient.DeleteAsync(HttpClient.BaseAddress + $"patient/{Id}");
            NavigationManager.NavigateTo("/");
        }
    }
}
