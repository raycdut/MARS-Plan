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

    using MeetingRoomReservation.Data.SqlServer.Migrations;

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
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ReservationContext, Configuration>("DefaultConnection"));
        }

        /// <summary>
        ///     Gets or sets the rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}