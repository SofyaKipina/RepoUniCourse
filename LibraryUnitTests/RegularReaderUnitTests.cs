using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace LibraryUnitTests
{
    [TestFixture]
    public class RegularReaderUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var sam = GetTestRegularReader();
            Assert.That(sam.RegistrationDate.ToString("dd.MM.yyyy"), Is.EqualTo("02.05.2025"));
            Assert.That(sam.Address, Is.EqualTo("45 Maple Street, London"));
            Assert.That(sam.PhoneNumber, Is.EqualTo("07123 456789"));
        }

        [Test]
        public void GetInfo_RegularReader_TwoStringInfo()
        {
            var sam = GetTestRegularReader();
            var lines = new[]
            {
                "Sam Brown Номер читательского билета: 456258",
                "Постоянный читатель. Дата записи в библиотеку: 02.05.2025. Адрес: 45 Maple Street, London. Номер телефона: 07123 456789.",
            };
            var info = sam.GetInfo();
            Assert.That(info.Length, Is.EqualTo(2));
            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private RegularReader GetTestRegularReader()
        {
            var sam = new RegularReader("Sam", "Brown", 456258);
            sam.RegistrationDate = DateTime.Parse("02.05.2025");
            sam.Address = "45 Maple Street, London";
            sam.PhoneNumber = "07123 456789";
            return sam;
        }

    }
}
