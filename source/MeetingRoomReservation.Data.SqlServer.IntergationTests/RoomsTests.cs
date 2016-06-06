// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomsTests.cs" company="">
//   
// </copyright>
// <summary>
//   The rooms tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MeetingRoomReservation.Data.SqlServer.IntergationTests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    ///     The rooms tests.
    /// </summary>
    [TestFixture]
    public class RoomsTests
    {
        /// <summary>
        ///     The clear data.
        /// </summary>
        [TearDown]
        public void ClearData()
        {
            using (var db = new ReservationContext())
            {
                foreach (var item in db.Rooms)
                {
                    db.Rooms.Remove(item);
                }

                db.SaveChanges();
                Assert.IsTrue(db.Rooms.FirstOrDefault() == null);
            }
        }

        /// <summary>
        ///     The test add room.
        /// </summary>
        [Test]
        public void TestAddRoom()
        {
            using (var db = new ReservationContext())
            {
                var room = new Room
                               {
                                   RoomId = Guid.NewGuid(), 
                                   Capacity = RoomCapacity.Small, 
                                   CreatedBy = "ddd", 
                                   CreatedDate = DateTime.UtcNow, 
                                   HasProjector = true, 
                                   RoomName = "AAA", 
                                   SeatNumber = 10
                               };
                db.Rooms.Add(room);
                db.SaveChanges();
                Assert.IsTrue(db.Rooms.FirstOrDefault(i => i.RoomId == room.RoomId) != null);
            }
        }

        /// <summary>
        ///     The test rooms.
        /// </summary>
        [Test]
        public void TestRooms()
        {
            using (var db = new ReservationContext())
            {
                Assert.IsNotNull(db);

                Assert.IsTrue(db.Rooms.Count() >= 0);
            }
        }
    }
}