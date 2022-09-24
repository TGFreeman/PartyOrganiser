namespace PartyOrganiserWebApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Event Party { get; set; }

    }
}
