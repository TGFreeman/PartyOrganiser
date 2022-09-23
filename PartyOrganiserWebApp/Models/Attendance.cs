namespace PartyOrganiserWebApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Party Party { get; set; }

        public Drink Drink { get; set; }
    }
}
