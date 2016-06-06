// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailService.cs" company="">
//   
// </copyright>
// <summary>
//   The email service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    /// <summary>
    /// The email service.
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// The send async.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager which is used in this application.

    // Configure the application sign-in manager which is used in this application.  
}