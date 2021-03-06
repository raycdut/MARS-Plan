// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumTypeModelDescription.cs" company="">
//   
// </copyright>
// <summary>
//   The enum type model description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The enum type model description.
    /// </summary>
    public class EnumTypeModelDescription : ModelDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTypeModelDescription"/> class.
        /// </summary>
        public EnumTypeModelDescription()
        {
            this.Values = new Collection<EnumValueDescription>();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        public Collection<EnumValueDescription> Values { get; private set; }
    }
}