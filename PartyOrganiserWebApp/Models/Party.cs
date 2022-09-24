namespace PartyOrganiserWebApp.Models
{
    public class Party : Event
    {
        public PartyAttendance AddAttendance(Person guest, Drink drink)
        {
            PartyAttendance partyAttendance = new PartyAttendance
            {
                Person = guest,
                Drink = drink,
                Party = this
            };
            return partyAttendance;
        }

    }
}
