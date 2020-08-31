using System.Linq;
using System.Security.Claims; 


namespace Sample.HelloWorld.Extensions
{
    public static class ClaimsPrincipalsExtensions
    {
        /// <summary>
        /// Helper method to extract the username from the clains
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            var usernameAttribute = principal.Claims.FirstOrDefault(c => c.Type == "username");
            return usernameAttribute == null ? string.Empty : usernameAttribute.Value.Trim(); 
        }
    }
}
