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
    internal class VisitorUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var sam = GetTestVisitor();
            Assert.That(sam.ComingInTime.ToString("HH:mm"), Is.EqualTo("17:04"));
            Assert.That(sam.LeavingTime.ToString("HH:mm"), Is.EqualTo("18:44"));
            Assert.That(sam.Document, Is.EqualTo("Driver's license"));
            Assert.That(sam.DocumentNumber, Is.EqualTo(258634));
        }

        [Test]
        public void GetInfo_Visitor_TwoStringInfo()
        {
            var sam = GetTestVisitor();
            var lines = new[]
            {
                "Sam Brown Номер читательского билета: 456258",
                "Посетитель. Время прихода: 17:04. Время ухода: 18:44. Название удостоверения личности: Driver's license. Номер удостоверения: 258634.",
            };
            var info = sam.GetInfo();
            Assert.That(info.Length, Is.EqualTo(2));
            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private Visitor GetTestVisitor()
        {
            var sam = new Visitor("Sam", "Brown", 456258);
            sam.ComingInTime = DateTime.Parse("17:04");
            sam.LeavingTime = DateTime.Parse("18:44");
            sam.Document = "Driver's license";
            sam.DocumentNumber = 258634;
            return sam;
        }
    }
}
