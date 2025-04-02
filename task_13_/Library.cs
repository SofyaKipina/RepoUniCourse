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
        public readonly DateTime IssueDate;
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
            info[0] = $"{Name} {Surname}";
            info[1] = $"Номер читательского билета: {LibraryCardId}, Список взятой литературы: {BorrowedLiterature}, " +
                $"Дата выдачи: {IssueDate}, Срок выдачи: {TermDate}, " +
                $"Дата планируемого возвращения: {ReturnDate}, Сумма залога: {Deposit}";
            return info;
        }

    }
}
