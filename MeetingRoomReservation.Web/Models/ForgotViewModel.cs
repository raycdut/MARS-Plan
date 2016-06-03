// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The forgot view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The forgot view model.
    /// </summary>
    public class ForgotViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}