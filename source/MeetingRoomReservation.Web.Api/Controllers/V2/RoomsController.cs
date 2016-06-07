namespace MeetingRoomReservation.Web.Api.Controllers.V2
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http;

    using MeetingRoomReservation.Data.SqlServer.IRepository;
    using Common;
    public class RoomsController : ApiControllerWrapper
    {
        public RoomsController(IRoomRepository repository)
        {
            this.RoomRepository = repository;
        }

        private IRoomRepository RoomRepository { get; }

        // GET: api/Rooms
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, this.RoomRepository.Get(), new JsonMediaTypeFormatter());

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