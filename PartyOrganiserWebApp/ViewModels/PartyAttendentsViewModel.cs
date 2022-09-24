using PartyOrganiserWebApp.Models;

namespace PartyOrganiserWebApp.ViewModels
{
    public class PartyAttendantsViewModel
    {
        public PartyAttendantsViewModel(List<PartyAttendance> attendances, Party party)
        {
            Attendances = attendances;
            Party = party;
        }

        public List<PartyAttendance> Attendances { get; set; }
        public Party Party { get; set; }
    }
}
