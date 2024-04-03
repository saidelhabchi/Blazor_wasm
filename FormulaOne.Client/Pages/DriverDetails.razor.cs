using FormulaOne.Client.Services;
using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace FormulaOne.Client.Pages
{
    public partial class DriverDetails
    {
        protected string Message { get; set; } = string.Empty;
        protected Driver Driver { get; set; } = new Driver();
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IDriverService driverService { get; set; }
        [Inject]
        private NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                // adding a new driver

            }
            else
            {
                //update driver
                var result = await driverService.GetDriver(Id);
                if (result != null) {
                    Driver = result;
                }
            }
        }

    }
}
