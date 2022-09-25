using PartyOrganiserWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyOrganiserTests
{
    public class BasePartyOrganiserTests
    {
        protected Party CreateDefaultParty()
        {
            Party party = new Party();
            party.Id = 1;
            party.Name = "Default party";
            party.StartDate = DateTime.Now;
            party.Attendances = new List<Attendance>();
            return party;
        }
        protected Drink CreateDefaultDrink()
        {
            return new Drink
            {
                Id = 1,
                Name = "Water"
            };
        }
        protected Person CreateDefaultPerson()
        {
            return new Person
            {
                FirstName = "Guest",
                LastName = "One",
                Id = 1
            };
        }
    }
}
