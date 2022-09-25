using PartyOrganiserWebApp.Models;

namespace PartyOrganiserWebApp.Validators
{
    public static class PartyAttendanceDuplicatePersonChecker
    {
        public static bool DuplicatePeopleAttending(Person attendee, BaseParty party)
        {
            return party.Attendances.Any(x => x.PersonId == attendee.Id);
        }
    }
}
