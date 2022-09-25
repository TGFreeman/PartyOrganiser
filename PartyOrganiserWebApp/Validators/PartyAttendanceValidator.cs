using PartyOrganiserWebApp.Models;

namespace PartyOrganiserWebApp.Validators
{
    public static class PartyAttendanceValidator
    {
        public static bool Validate(PartyAttendance partyAttendance)
        {
           
            if(partyAttendance == null)
            {
                throw new ArgumentNullException(nameof(partyAttendance));
            }
            if(partyAttendance.Person == null)
            {
                throw new ArgumentNullException(nameof(partyAttendance.Person));
            }

            if (partyAttendance.Party == null)
            {
                throw new ArgumentNullException(nameof(partyAttendance.Party));
            }

            if (partyAttendance.Drink == null)
            {
                throw new ArgumentNullException(nameof(partyAttendance.Drink));
            }
            if (PartyAttendanceDuplicatePersonChecker.DuplicatePeopleAttending(partyAttendance.Person, partyAttendance.Party))
            {
                return false;
            }
            return true;
        }

       
    }
}
