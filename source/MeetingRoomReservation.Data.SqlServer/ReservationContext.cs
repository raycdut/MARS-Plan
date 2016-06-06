// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReservationContext.cs" company="">
//   
// </copyright>
// <summary>
//   The reservation context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Data.SqlServer
{
    using System.Data.Entity;

    /// <summary>
    ///     The reservation context.
    /// </summary>
    public class ReservationContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReservationContext" /> class.
        /// </summary>
        public ReservationContext()
            : base("DefaultConnection")
        {
            
        }

        /// <summary>
        ///     Gets or sets the rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}