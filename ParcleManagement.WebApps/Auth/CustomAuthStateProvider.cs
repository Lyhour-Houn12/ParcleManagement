using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ParcleManagement.WebApps.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private UserSession? _session;

        public void SetUser(UserSession session)
        {
            _session = session;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void Logout()
        {
            _session = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_session == null)
            {
                var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                return Task.FromResult(new AuthenticationState(anonymous));
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, _session.UserId.ToString()),
                new Claim(ClaimTypes.Name, _session.FullName),
                new Claim(ClaimTypes.Email, _session.Email),
            };

            var identity = new ClaimsIdentity(claims, "CustomAuth");
            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
