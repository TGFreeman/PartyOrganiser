using PartyOrganiserWebApp.Models;

namespace PartyOrganiserWebApp.Validators
{
    public static class PartyAttendanceValidator
    {
        public static bool Validate(PartyAttendance partyAttendance, BaseParty party)
        {
            if (party == null)
            {
                throw new ArgumentNullException(nameof(party));
            }
            if(partyAttendance == null)
            {
                throw new ArgumentNullException(nameof(partyAttendance));
            }

            if(DuplicatePeopleAttending(partyAttendance.Person, party))
            {
                return false;
            }
            return true;
        }

        private static bool DuplicatePeopleAttending(Person attendee, BaseParty party)
        {
            return party.Attendances.Any(x => x.PersonId == attendee.Id);
        }
    }
}
