using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebApi_Common.Models;

namespace AssistantClient.Pages
{
    public partial class AddPatient
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Patient Patient { get; set; } = new Patient();

        private string _statusMessage;
        private string _statusClass;

        private async Task Submit()
        {
            await HttpClient.PostAsJsonAsync("patient", Patient);
            _statusClass = "alert-info";
            _statusMessage = "Beteg rögzítve";
            await Task.Delay(3000);
            ClearInputFields();

        }
        private void ClearInputFields()
        {
            Patient.Name = String.Empty;
            Patient.Address = String.Empty;
            Patient.SocialSecurityNumber = String.Empty;
            Patient.Symptom = String.Empty;
        }

        private async Task InvalidSubmit()
        {
            _statusClass = "alert-danger";
            _statusMessage = "A beteg rögzítése sikertelen";
        }

    }
}
