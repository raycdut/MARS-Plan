namespace MeetingRoomReservation.Web.Api.Models
{
    using System;

    public class RoomVm
    {
        public Guid RoomId { get; set; }

        public string BookedBy { get; set; }

        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public string Subject { get; set; }

        public string Comments { get; set; }
    }
}