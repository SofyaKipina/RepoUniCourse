using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.UnitTests
{
    [TestFixture]
    public class PersonUnitTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var john = CreateTestPerson();

            Assert.That(john.Name, Is.EqualTo("John"));
            Assert.That(john.SurName, Is.EqualTo("Smith"));
            Assert.That(john.BorrowedLiterature, Is.EqualTo(" 'One Hundred Years of Solitude' Gabriel García Márquez, 'First Love And Other Stories' Ivan Turgenev "));
            Assert.That(john.IssueDate.ToShortDateString(), Is.EqualTo("15.07.2003"));

            Assert.That(john.TermDate, Is.EqualTo(5));
            Assert.That(john.ReturnDate.ToShortDateString(), Is.EqualTo(IssueDate.AddDays(TermDate)));
        }
        [Test]
        public void GetInfoTest()
        {
            var john = CreateTestPerson();
            var info = john.GetInfo();
            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("John Smith"));
            Assert.That($"Дата рождения: 15.07.2003. Пол: мужской. Возраст: { DateTime.Now.Year - 2003}.", Is.EqualTo(info[1]));
        }
        private Person CreateTestPerson()
        {
            return new Person("John", "Smith", 123456, " 'One Hundred Years of Solitude' Gabriel García Márquez, 'First Love And Other Stories' Ivan Turgenev ", "10.03.2025", 5);
        }
    }
}
