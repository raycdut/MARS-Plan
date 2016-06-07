namespace MeetingRoomReservation.Data.SqlServer.IntergationTests
{
    using System;

    using MeetingRoomReservation.Data.SqlServer.Repository;

    using NUnit.Framework;

    [TestFixture]
    public class RoomRepositoryTest
    {
        [Test]
        public void AddRoomTest()
        {
            var rp = new RoomRepository();
            rp.AddRoom(new Room()
            {
                RoomId = Guid.NewGuid(),
                Capacity = RoomCapacity.Small,
                CreatedBy = "dddUNIT",
                CreatedDate = DateTime.UtcNow,
                HasProjector = true,
                RoomName = "AAA",
                SeatNumber = 10
            });
        }
    }
}