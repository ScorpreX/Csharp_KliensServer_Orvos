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

        private async Task Submit()
        {
            await HttpClient.PostAsJsonAsync("patient", Patient);
        }

    }
}
