using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace LibraryUnitTests 
{
    [TestFixture] 
    public class LibraryUnitTests
    {
        Library.Library library;
        RegularReader[] members;

        [SetUp]
        public void Setup()
        {
            var peter = new RegularReader("Peter", "Gabriel", 456892);
            var kate = new RegularReader("Kate", "Bush", 82631);
            var phil = new RegularReader("Phil", "Collins", 444125);
            var john = new RegularReader("John", "Fogerty", 602158);
            var tom = new RegularReader("Tom", "Fogerty", 369778);

            members = new RegularReader[] { peter, kate, phil, john, tom, peter };
            library = new Library.Library("UCL Main Library", "Wilkins Building, Gower St, London", members);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(library.Title, Is.EqualTo("UCL Main Library"));
            Assert.That(library.Address, Is.EqualTo("Wilkins Building, Gower St, London"));

            foreach (var member in members)
                Assert.That(library.Count(s => s.Equals(member)), Is.EqualTo(1));
        }


        [Test]
        public void CountTest()
        {
            Assert.That(library.Count, Is.EqualTo(5));
        }
        [Test]
        public void IEnumerableTest()
        {
            var i = 0;
            foreach (var reader in library)
                Assert.That(reader, Is.SameAs(members[i++]));
        }

    }
}
