namespace MeetingRoomReservation.Web.Api.Controllers.V2
{
    using System.Collections.Generic;
    using System.Web.Http;

    using MeetingRoomReservation.Data;
    using MeetingRoomReservation.Data.SqlServer.IRepository;

    public class RoomsController : ApiController
    {
        public RoomsController(IRoomRepository repository)
        {
            this.RoomRepository = repository;
        }

        private IRoomRepository RoomRepository { get; }

        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return this.RoomRepository.Get();
        }

        // GET: api/Rooms/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rooms
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
        }
    }
}