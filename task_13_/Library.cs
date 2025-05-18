using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public readonly int LibraryCardId;

        public string BorrowedLiterature;
        public DateTime IssueDate;
        public double TermDate;
        public DateTime ReturnDate => IssueDate.AddDays(TermDate);
        public int Deposit;

        public Person(string name, string surename, int libraryCardId)
        {
            Name = name;
            Surname = surename;
            LibraryCardId = libraryCardId;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} {Surname} Номер читательского билета: {LibraryCardId}";
            info[1] = $"Список взятой литературы: {BorrowedLiterature}, " +
                $"Дата выдачи: {IssueDate.ToString("dd.MM.yyyy")}, Срок выдачи: {TermDate}, " +
                $"Дата планируемого возвращения: {ReturnDate.ToString("dd.MM.yyyy")}, Сумма залога: {Deposit}";
            return info;
        }

    }

    public class RegularReader : Person
    {
        public DateTime RegistrationDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public RegularReader(string name, string surename, int libraryCardId) : base(name, surename, libraryCardId)
        {
        }

        public override string[] GetInfo()
        {
            var info = new string[2];
            var personInfo = base.GetInfo();

            info[0] = personInfo[0];
            info[1] = $"Постоянный читатель. Дата записи в библиотеку: {RegistrationDate.ToString("d")}. Адрес: {Address}. Номер телефона: {PhoneNumber}.";

            return info;
        }


    }

    public class TemporaryReader : Person
    {
        public DateTime EndDate { get; set; }
        public string Departaments { get; set; }

        public TemporaryReader(string name, string surename, int libraryCardId) : base(name, surename, libraryCardId)
        {
        }

        public override string[] GetInfo()
        {
            var info = new string[2];
            var personInfo = base.GetInfo();

            info[0] = personInfo[0];
            info[1] = $"Временный читатель. Дата окончания допуска в библиотеку: {EndDate.ToString("d")}. Отделы: {Departaments}.";

            return info;
        }

    }

    public class Visitor : Person
    {
        public DateTime ComingInTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public string Document { get; set; }
        public int DocumentNumber { get; set; }

        public Visitor(string name, string surename, int libraryCardId) : base(name, surename, libraryCardId)
        {
        }

         public override string[] GetInfo()
        {
            var info = new string[2];
            var personInfo = base.GetInfo();

            info[0] = personInfo[0];
            info[1] = $"Посетитель. Время прихода: {ComingInTime:t}. Время ухода: {LeavingTime:t}. Название удостоверения личности: {Document}. Номер удостоверения: {DocumentNumber}.";

            return info;
        }
    }
}
