namespace PartyOrganiserWebApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Person? Person { get; set; }
        public int PersonId { get; set; }
        public BaseParty? Party { get; set; }
        public int PartyId { get; set; }

    }
}
