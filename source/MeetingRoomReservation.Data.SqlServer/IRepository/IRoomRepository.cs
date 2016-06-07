namespace MeetingRoomReservation.Data.SqlServer.IRepository
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        void AddRoom(Room room);
    }
}