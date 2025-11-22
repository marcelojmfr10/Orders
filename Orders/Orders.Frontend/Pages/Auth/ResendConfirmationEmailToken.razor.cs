using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Shared.DTOs;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.Auth
{
    public partial class ResendConfirmationEmailToken
    {
        private EmailDTO emailDTO = new();
        private bool loading;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;

        private async Task ResendConfirmationEmailTokenAsync()
        {
            loading = true;
            var responseHttp = await Repository.PostAsync($"/api/accounts/ResendToken", emailDTO);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                loading = false;
                return;
            }

            await SweetAlertService.FireAsync("Confirmación", "Se ha enviado un correo electrónico con las instrucciones para activar la cuenta.", SweetAlertIcon.Info);
            NavigationManager.NavigateTo("/");
        }
    }
}