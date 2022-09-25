using PartyOrganiserWebApp.Models;
using PartyOrganiserWebApp.Validators;

namespace PartyOrganiserTests
{
    [TestClass]
    public class AttendanceTests : BasePartyOrganiserTests
    {

        [TestMethod]

        public void Constructor()
        {
            Person person = CreateDefaultPerson();
            Party party = CreateDefaultParty();
            Assert.IsNotNull(party);
            Assert.IsNotNull(person);
            Attendance att = new Attendance(person, party);
            Assert.AreEqual(party, att.Party);
            Assert.AreEqual(party.Id, att.PartyId);
            Assert.AreEqual(person, att.Person);
            Assert.AreEqual(person.Id, att.PersonId);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPersonAttendanceParameterThrowArgumentNullException()
        {
            Party party = CreateDefaultParty();
            Assert.IsNotNull(party);
            Attendance att = new Attendance(null, party);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPartyAttendanceParameterThrowArgumentNullException()
        {
            Person person = CreateDefaultPerson();
            Assert.IsNotNull(person);
            Attendance att = new Attendance(person, null);
        }

    }
}