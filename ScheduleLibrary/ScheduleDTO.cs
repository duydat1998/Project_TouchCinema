using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleLibrary
{
    public class ScheduleDTO
    {
        public string ScheduleID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string MovieID { get; set; }
        public int RoomID { get; set; }
        public float PriceOfTicket { get; set; }
    }
}
