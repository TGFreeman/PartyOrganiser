using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyOrganiserWebApp.Models
{
    public class PartyAttendance : Attendance
    {
        
        public Drink Drink { get; set; }
    }
}
