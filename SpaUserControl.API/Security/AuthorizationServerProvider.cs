//using Microsoft.Owin.Security.OAuth;
//using SpaUserControl.Common.Resources;
//using SpaUserControl.Domain.Contracts.Services;
//using System;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Threading;
//using System.Threading.Tasks;

//namespace SpaUserControl.API.Security
//{
//    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
//    {

//            private readonly IUserServices _service;

//        public AuthorizationServerProvider(IUserServices service)
//        {
//            _service = service;

//        }

//        //valida um token existente
//        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
//            context.Validated();
//        }

//        //caso não exista um token
//        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {
//            //habilita o Cors
//            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

//            try
//            {//tenta fazer autenticação
//                var user = _service.Authenticate(context.UserName, context.Password);

//                //se falhar
//                if(user == null)
//                {
//                    context.SetError("invalid_grant", Errors.InvalidCredentials);
//                    return;
//                }

//                //inicia a criação de um claim
//                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

//                //adiciona claims que são importantes
//                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
//                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

//                //cria generic principal 
//                //setar a thread atual como esse user
//                GenericPrincipal principal = new GenericPrincipal(identity, null);
//                Thread.CurrentPrincipal = principal;

//                context.Validated(identity);
//            }
//            catch(Exception ex)
//            {
//                context.SetError("invalid-grant", Errors.InvalidCredentials);
//            }

//        }

//    }
//}
using Microsoft.Owin.Security.OAuth;
using SpaUserControl.Common.Resources;
using SpaUserControl.Domain.Contracts.Services;
//using SpaUserControl.Resource.Resources;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace SpaUserControl.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserServices _service;

        public AuthorizationServerProvider(IUserServices service)
        {
            _service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = _service.Authenticate(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", Errors.InvalidCredentials);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", Errors.InvalidCredentials);
            }
        }
    }
}