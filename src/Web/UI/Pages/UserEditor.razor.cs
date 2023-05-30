﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace UI.Pages
{
    public partial class UserEditor
    {
        [Parameter]
        public string UserId { get; set; } = null!;

        [Inject]
        public IUsersClient UsersClient { get; set; } = null!;

        public UserDetailsViewModel? Model { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Model = await UsersClient.GetUserAsync(UserId);
        }

        public void ToggleSelectedRole(string roleName)
        {
            if (Model!.Roles.Any(role => role.Name == roleName))
            {
                Model!.User.Roles.Remove(roleName);
            }
            else
            {
                Model.User.Roles.Add(roleName);
            }

            StateHasChanged();
        }
    }
}
