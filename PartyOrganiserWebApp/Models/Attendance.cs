namespace PartyOrganiserWebApp.Models
{
    public class Attendance
    {
        public Attendance()
        {

        }

        public Attendance(Person person, BaseParty party)
        {
            if(person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            if (party == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            Person = person;
            Party = party;
            PersonId = person.Id;
            PartyId = party.Id;
        }

        public int Id { get; set; }
        public Person? Person { get; set; }
        public int PersonId { get; set; }
        public BaseParty? Party { get; set; }
        public int PartyId { get; set; }

    }
}
