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
    /// The reservation context.
    /// </summary>
    public class ReservationContext : DbContext
    {
        public  DbSet<Room> Rooms { get; set; }
    }
}