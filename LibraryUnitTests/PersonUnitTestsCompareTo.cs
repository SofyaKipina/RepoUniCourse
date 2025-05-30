using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace LibraryUnitTests
{
    [TestFixture]
    public class PersonUnitTestsCompareTo
    {
        [Test]
        public void CompareToTest()
        {
            var peter = new Person("Peter", "Gabriel", 456892);
            var kate = new Person("Kate", "Bush", 82631);
            var phil = new Person("Phil", "Collins", 444125);
            var john = new Person("John", "Fogerty", 602158);
            var tom = new Person("Tom", "Fogerty", 369778);

            Assert.That(kate.CompareTo(phil), Is.LessThan(0));
            Assert.That(phil.CompareTo(peter), Is.LessThan(0));
            Assert.That(john.CompareTo(peter), Is.LessThan(0));
            Assert.That(tom.CompareTo(john), Is.GreaterThan(0));
            
        }
    }
}
