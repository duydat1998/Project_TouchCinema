using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLibary
{
    public class OrderDTO
    {
        public string OrderID { get; set; }
        public string ScheduleID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsCheckOut { get; set; }
        public List<string> ListOfSeat { get; set; }
    }
}
