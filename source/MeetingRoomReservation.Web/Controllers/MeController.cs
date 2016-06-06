// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeController.cs" company="">
//   
// </copyright>
// <summary>
//   The me controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Controllers
{
    using System.Web;
    using System.Web.Http;

    using MeetingRoomReservation.Web.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    /// <summary>
    /// The me controller.
    /// </summary>
    [Authorize]
    public class MeController : ApiController
    {
        /// <summary>
        /// The _user manager.
        /// </summary>
        private ApplicationUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeController"/> class.
        /// </summary>
        public MeController()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeController"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        public MeController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return this._userManager
                       ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this._userManager = value;
            }
        }

        // GET api/Me
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="GetViewModel"/>.
        /// </returns>
        public GetViewModel Get()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            return new GetViewModel { Hometown = user.Hometown };
        }
    }
}