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
            Assert.That(john.IssueDate.ToString("dd.MM.yyyy"), Is.EqualTo("10.03.2025"));

            Assert.That(john.TermDate, Is.EqualTo(5));
            Assert.That(john.ReturnDate.Date, Is.EqualTo(john.IssueDate.AddDays(5).Date)); 
        }

        [Test]
        public void GetInfoTest()
        {
            var john = CreateTestPerson();
            var info = john.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("John Smith Номер читательского билета: 123456"));
            Assert.That(info[1], Is.EqualTo($"Список взятой литературы: 'First Love And Other Stories' Ivan Turgenev, " +
                $"Дата выдачи: 10.03.2025, Срок выдачи: 5, Дата планируемого возвращения: 15.03.2025, " +
                $"Сумма залога: 100"));
        }
        private Person CreateTestPerson()
        {
            return new Person("John", "Smith", 123456)
            {
                BorrowedLiterature = "'First Love And Other Stories' Ivan Turgenev",
                IssueDate = new DateTime(2025, 03, 10),
                TermDate = 5,
                Deposit = 100
            };
        }


    }
}