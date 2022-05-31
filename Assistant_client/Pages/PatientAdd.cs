using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using WebApi_Common.Models;

namespace Assistant_client.Pages
{
    public partial class PatientAdd : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Patient Patient { get; set; } = new Patient();

        private  async Task SubmitForm()
        {
            await HttpClient.PostAsJsonAsync("patient", Patient);
        }


    }


}
