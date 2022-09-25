using PartyOrganiserWebApp.Models;
using PartyOrganiserWebApp.Validators;

namespace PartyOrganiserTests
{
    [TestClass]
    public class PartyOrganiserValidatorTests : BasePartyOrganiserTests
    {
        [TestMethod]
        public void DuplicatePeopleNotAllowed()
        {
            Party party = CreateDefaultParty();
            Person guest1 = new Person
            {
                FirstName = "Guest",
                LastName = "One",
                Id = 1
            };
            var drink1 = CreateDefaultDrink();
            PartyAttendance att = new PartyAttendance(drink1, guest1, party);
            att.Id = 123;


            bool validatorResult = PartyAttendanceValidator.Validate(att, party);
            Assert.IsTrue(validatorResult);
            party.Attendances.Add(att);
            Assert.IsTrue(party.Attendances.Any(x => x.PersonId == guest1.Id));
            Assert.IsTrue(party.Attendances.Any(x => x.Id == att.Id));

            PartyAttendance att2 = new PartyAttendance(drink1, guest1, party);
            att.Id = 1234;

            validatorResult = PartyAttendanceValidator.Validate(att2, party);
            Assert.IsFalse(validatorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPartyParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
            Person guest1 = new Person
            {
                FirstName = "Guest",
                LastName = "One",
                Id = 1
            };
            Drink drink1 = new Drink
            {
                Id = 1,
                Name = "Water"
            };
            PartyAttendance att = new PartyAttendance(drink1, guest1, party);
            att.Id = 123;


            bool validatorResult = PartyAttendanceValidator.Validate(att, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPartyAttendanceParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
           
            bool validatorResult = PartyAttendanceValidator.Validate(null, party);
        }

    }
}