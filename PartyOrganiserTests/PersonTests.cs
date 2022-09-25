using PartyOrganiserWebApp.Models;
using PartyOrganiserWebApp.Validators;

namespace PartyOrganiserTests
{
    [TestClass]
    public class PersonTests : BasePartyOrganiserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonNameProperty()
        {
            Person person = CreateDefaultPerson();
            Assert.IsNotNull(person);
            Assert.AreEqual($"{person.FirstName} {person.LastName}", person.Name);
        }
    }
}