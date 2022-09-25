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
            Person guest1 = CreateDefaultPerson();
            var drink1 = CreateDefaultDrink();
            PartyAttendance att = new PartyAttendance(drink1, guest1, party);
            att.Id = 123;


            bool validatorResult = PartyAttendanceValidator.Validate(att);
            Assert.IsTrue(validatorResult);
            party.Attendances.Add(att);
            Assert.IsTrue(party.Attendances.Any(x => x.PersonId == guest1.Id));
            Assert.IsTrue(party.Attendances.Any(x => x.Id == att.Id));

            PartyAttendance att2 = new PartyAttendance(drink1, guest1, party);
            att.Id = 1234;

            validatorResult = PartyAttendanceValidator.Validate(att2);
            Assert.IsFalse(validatorResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPartyParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
            Person guest1 = CreateDefaultPerson();
            Drink drink1 = CreateDefaultDrink();
            PartyAttendance att = new PartyAttendance(drink1, guest1, party);
            att.Id = 123;
            att.Party = null;

            bool validatorResult = PartyAttendanceValidator.Validate(att);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPersonParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
            Person guest1 = CreateDefaultPerson();
            Drink drink1 = CreateDefaultDrink();
            PartyAttendance att = new PartyAttendance(drink1, guest1, party);
            att.Id = 123;
            att.Person = null;

            bool validatorResult = PartyAttendanceValidator.Validate(att);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullDrinkParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
            Person guest1 = CreateDefaultPerson();
            Drink drink1 = CreateDefaultDrink();
            PartyAttendance att = new PartyAttendance(drink1, guest1, party);
            att.Id = 123;
            att.Drink = null;

            bool validatorResult = PartyAttendanceValidator.Validate(att);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPartyAttendanceParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
           
            bool validatorResult = PartyAttendanceValidator.Validate(null);
        }

    }
}