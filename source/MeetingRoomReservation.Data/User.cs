using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomReservation.Data
{
    public class User
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
