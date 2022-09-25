using PartyOrganiserWebApp.Models;
using PartyOrganiserWebApp.Validators;

namespace PartyOrganiserTests
{
    [TestClass]
    public class PartyAttendanceTests : BasePartyOrganiserTests
    {
        [TestMethod]
       
        public void Constructor()
        {
            Person person = CreateDefaultPerson();
            Party party = CreateDefaultParty();
            Drink drink = CreateDefaultDrink();
            Assert.IsNotNull(party);
            Assert.IsNotNull(person);
            Assert.IsNotNull(drink);
            PartyAttendance att = new PartyAttendance(drink, person, party);
            Assert.AreEqual(drink, att.Drink);
            Assert.AreEqual(drink.Id, att.DrinkId);
            Assert.AreEqual(party, att.Party);
            Assert.AreEqual(party.Id, att.PartyId);
            Assert.AreEqual(person, att.Person);
            Assert.AreEqual(person.Id, att.PersonId);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullDrinkParameterThrowArgumentNullException()
        {
            Person person = CreateDefaultPerson();
            Party party = CreateDefaultParty();
            Assert.IsNotNull(party);
            Assert.IsNotNull(person);
            PartyAttendance att = new PartyAttendance(null, person, party);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPersonAttendanceParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
            Drink drink = CreateDefaultDrink();
            Assert.IsNotNull(party);
            Assert.IsNotNull(drink);
            PartyAttendance att = new PartyAttendance(drink, null, party);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPartyAttendanceParameterThrowArgumentNullException()
        {
            Person person = CreateDefaultPerson();
            Drink drink = CreateDefaultDrink();
            Assert.IsNotNull(person);
            Assert.IsNotNull(drink);
            PartyAttendance att = new PartyAttendance(drink, person, null);
        }

    }
}