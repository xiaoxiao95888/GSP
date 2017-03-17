using System.Security.Principal;

namespace Gsp.Api.Infrastructure
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly CustomIdentity _identity;

        public CustomPrincipal(CustomIdentity identity)
        {
            _identity = identity;
        }

        public IIdentity Identity => _identity;

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}