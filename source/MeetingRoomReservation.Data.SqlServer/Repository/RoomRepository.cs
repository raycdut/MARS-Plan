namespace MeetingRoomReservation.Data.SqlServer.Repository
{
    using MeetingRoomReservation.Data.SqlServer.IRepository;

    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository()
        {
        }

        public RoomRepository(ReservationContext dbCtx)
            : base(dbCtx)
        {
        }

        public void AddRoom(Room room)
        {
            this.Insert(room);
        }
    }
}