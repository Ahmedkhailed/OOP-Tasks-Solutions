using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1_oop.Properties
{
    public class BorrowingHistory
    {
        public Member Member { get; private set; }
        public Book Book { get; private set; }
        public DateTime BorrowingDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public BorrowingHistory(Member member, Book book)
        {
            this.Member = member;
            this.Book = book;
            BorrowingDate = DateTime.Now;
            ReturnDate = null;
        }

        public void receiveBook()
        {
            ReturnDate = DateTime.Now;
        }
    }
}
