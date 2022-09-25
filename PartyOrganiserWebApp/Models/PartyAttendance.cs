using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyOrganiserWebApp.Models
{
    public class PartyAttendance : Attendance
    {
        public PartyAttendance() : base()
        {

        }
        public PartyAttendance(Drink drink, Person person, Party party) : base(person, party)
        {
            if(drink == null)
            {
                throw new ArgumentNullException(nameof(drink));
            }
            Drink = drink;
            DrinkId = drink.Id;
        }

        public Drink? Drink { get; set; }
        public int DrinkId { get; set; }
    }
}
