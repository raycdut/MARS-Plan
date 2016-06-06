// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Room.cs" company="">
//   
// </copyright>
// <summary>
//   The room.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MeetingRoomReservation.Data
{
    using System;

    /// <summary>
    ///     The room.
    /// </summary>
    public class Room
    {
        /// <summary>
        ///     Gets or sets the room id.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        ///     Gets or sets the room name.
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether has projector.
        /// </summary>
        public bool HasProjector { get; set; }

        /// <summary>
        ///     Gets or sets the seat number.
        /// </summary>
        public int SeatNumber { get; set; }

        /// <summary>
        ///     Gets or sets the capacity.
        /// </summary>
        public RoomCapacity Capacity { get; set; }

        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}