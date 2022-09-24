using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyOrganiserWebApp.Models
{
    public abstract class BaseParty
    {
        public BaseParty()
        {
            Attendances = new List<Attendance>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<Attendance> Attendances {get;set;}

        
    }
}
