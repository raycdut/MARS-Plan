namespace MeetingRoomReservation.Data.SqlServer.IntergationTests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class UserTests
    {
        /// <summary>
        ///     The clear data.
        /// </summary>
        [TearDown]
        public void ClearData()
        {
            using (var db = new ReservationContext())
            {
                foreach (var item in db.Users)
                {
                    db.Users.Remove(item);
                }

                db.SaveChanges();
                Assert.IsTrue(db.Users.FirstOrDefault() == null);
            }
        }

        /// <summary>
        ///     The test add room.
        /// </summary>
        [Test]
        public void TestAddUser()
        {
            using (var db = new ReservationContext())
            {
                var user = new User { UserId = Guid.NewGuid(), UserName = "aaa", CreatedDate = DateTime.Now };
                db.Users.Add(user);
                db.SaveChanges();
                Assert.IsTrue(db.Users.FirstOrDefault(i => i.UserId == user.UserId) != null);
            }
        }

        /// <summary>
        ///     The test rooms.
        /// </summary>
        [Test]
        public void TestUser()
        {
            using (var db = new ReservationContext())
            {
                Assert.IsNotNull(db);

                Assert.IsTrue(db.Users.Count() >= 0);
            }
        }
    }
}