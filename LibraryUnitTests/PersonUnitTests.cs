using Library;
namespace LibraryUnitTests
{
    [TestFixture]
    public class PersonUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var john = CreateTestPerson();

            Assert.That(john.Name, Is.EqualTo("John"));
            Assert.That(john.Surname, Is.EqualTo("Smith"));
            Assert.That(john.LibraryCardId, Is.EqualTo(123456));
            Assert.That(john.BorrowedLiterature, Is.EqualTo("'First Love And Other Stories' Ivan Turgenev"));
            Assert.That(john.IssueDate.ToShortDateString(), Is.EqualTo("10.03.2025"));

            Assert.That(john.TermDate, Is.EqualTo(5));
            Assert.That(john.ReturnDate.ToShortDateString(), Is.EqualTo(IssueDate.AddDays(TermDate))); //Assert.That(john.ReturnDate.ToShortDateString(), Is.EqualTo(DateTime.AddDays(john.IssueDate, john.TermDate)));
        }

        [Test]
        public void GetInfoTest()
        {
            var john = CreateTestPerson();
            var info = john.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("John Smith"));
            Assert.That($"Номер читательского билета: 123456, Список взятой литературы: 'First Love And Other Stories' Ivan Turgenev, " +
                $"Дата выдачи: 10.03.25, Срок выдачи: 5 Дата планируемого возвращения: {IssueDate.AddDays(TermDate)}, " +
                $"Сумма залога: 100");
        }
        private Person CreateTestPerson()
        {
            return new Person("John", "Smith", 123456 );
        }
    }
}