using Microsoft.IdentityModel.Tokens;

namespace Ghost.books.Controllers
{
    internal class SigningCredetials : SigningCredentials
    {
        public SigningCredetials(SecurityKey key, string algorithm) : base(key, algorithm)
        {
        }
    }
}