namespace MeetingRoomReservation.Data.SqlServer.Repository
{
    using IRepository;

    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public void AddRoom(Room room)
        {
            this.Insert(room);
        }
    }
}