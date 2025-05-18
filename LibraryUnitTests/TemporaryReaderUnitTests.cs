using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace LibraryUnitTests
{
    [TestFixture]
    public class TemporaryReaderUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var sam = GetTestTemporaryReader();
            Assert.That(sam.EndDate.ToString("dd.MM.yyyy"), Is.EqualTo("02.05.2025"));
            Assert.That(sam.Departaments, Is.EqualTo("Archives"));
        }

        [Test]
        public void GetInfo_TemporaryReader_TwoStringInfo()
        {
            var sam = GetTestTemporaryReader();
            var lines = new[]
            {
                "Sam Brown Номер читательского билета: 456258",
                "Временный читатель. Дата окончания допуска в библиотеку: 02.05.2025. Отделы: Archives.",
            };
            var info = sam.GetInfo();
            Assert.That(info.Length, Is.EqualTo(2));
            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private TemporaryReader GetTestTemporaryReader()
        {
            var sam = new TemporaryReader("Sam", "Brown", 456258);
            sam.EndDate = DateTime.Parse("02.05.2025");
            sam.Departaments = "Archives";
            return sam;
        }

    }
}
