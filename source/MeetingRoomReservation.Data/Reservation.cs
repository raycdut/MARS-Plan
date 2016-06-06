namespace MeetingRoomReservation.Data
{
    using System;

    public class Reservation
    {
        public Guid ReservationId { get; set; }

        public virtual Room Room { get; set; }

        public virtual User User { get; set; }
    }
}