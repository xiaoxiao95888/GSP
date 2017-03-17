using System.Security.Principal;
using Gsp.Api.Models;

namespace Gsp.Api.Infrastructure
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(UserModel user)
        {
            User = user;
        }
        public UserModel User { get; }
        public string AuthenticationType => "Custom";
        public bool IsAuthenticated => User != null;
        public string Name => User == null ? "" : User.Token;
    }
}