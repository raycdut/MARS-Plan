// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationOAuthProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The application o auth provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Providers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// The application o auth provider.
    /// </summary>
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// The _public client id.
        /// </summary>
        private readonly string _publicClientId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationOAuthProvider"/> class.
        /// </summary>
        /// <param name="publicClientId">
        /// The public client id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            this._publicClientId = publicClientId;
        }

        /// <summary>
        /// The validate client redirect uri.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == this._publicClientId)
            {
                var expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    var expectedUri = new Uri(context.Request.Uri, "/");
                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}