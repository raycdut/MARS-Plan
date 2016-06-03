// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalLoginConfirmationViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The external login confirmation view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    // Models returned by AccountController actions.
    /// <summary>
    /// The external login confirmation view model.
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the hometown.
        /// </summary>
        [Display(Name = "Hometown")]
        public string Hometown { get; set; }
    }
}