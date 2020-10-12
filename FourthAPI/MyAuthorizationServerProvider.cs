using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using ApiDemoWithAuth.Services;
using ApiDemoWithAuth.Models;
namespace ApiDemoWithAuth
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
      
            
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
           // return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                string userName = context.UserName;
                string password = context.Password;
                UserService userFascade = new UserService();
                User userModel = userFascade.GetUserByUsernameAndPassword(userName, password);
                //identity.AddClaim(new Claim(ClaimTypes.Sid, userModel.UserId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, userModel.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, userModel.Role));
               // identity.AddClaim(new Claim(ClaimTypes.Gender, gender));
               // identity.AddClaim(new Claim("LastLoginTime", FormUtilities.DateFormatYYYYMMDDHHMMSS(userModel.LastLoginTime)));
                context.Validated(identity);
            }
            catch (Exception ex)
            {
            }
            return base.GrantResourceOwnerCredentials(context);


            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    if (context.UserName == "admin" && context.Password == "admin")
            //    {
            //        identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //        identity.AddClaim(new Claim("username", "admin"));
            //        identity.AddClaim(new Claim(ClaimTypes.Name, "Sourav Mondal"));
            //        context.Validated(identity);

            //    }
            //    else if (context.UserName == "user" && context.Password == "user")
            //    {
            //        identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            //        identity.AddClaim(new Claim("username", "user"));
            //        identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
            //        context.Validated(identity);
            //    }
            //    else
            //    {
            //        context.SetError("invalid_grant", "Provided username and password is incorrect");
            //        return;
            //    }
        }
    }
}