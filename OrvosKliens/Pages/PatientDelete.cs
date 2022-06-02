using Microsoft.AspNetCore.Components;

namespace OrvosKliens.Pages
{
    public partial class PatientDelete
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        private async Task DeletePatient()
        {
            await HttpClient.DeleteAsync(HttpClient.BaseAddress + $"/patient/{Id}");
            NavigationManager.NavigateTo("/patients");
        }
    }
}
