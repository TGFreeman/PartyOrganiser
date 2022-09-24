namespace PartyOrganiserWebApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public BaseParty Party { get; set; }

    }
}
