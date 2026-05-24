using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_oop
{
    public class Member
    {
        public string Name { get;private set; }
        public string MemberID { get;private set; }
        private List<Book> borrowedBooks { get; set; }

        public Member(string name, string memberDI)
        {
            this.Name = name;
            this.MemberID = memberDI;
            this.borrowedBooks = new List<Book>();
        }

        public string getInfo()
        {
            return $"Name: {Name}\nMemberID: {MemberID}";
        }

        public bool borrowBook(Book book)
        {
            if (book == null)
            {
                return false;
            }
            else if (borrowedBooks.Count >= 3)
            {
                Console.WriteLine("Sorry, you have exceeded the number of books you are allowed to borrow.");
            }
            else if (book.isAvailable)
            {
                if (book.borrow())
                {
                    borrowedBooks.Add(book);
                    Console.WriteLine($"\n{Name} borrowed: {book.title}\n");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("this book not available now");
            }
            return false;
        }

        public  bool returnBook(Book book)
        {
            if (book == null)
                return false;

            if (!book.isAvailable)
            {
                book.returnBook();
                borrowedBooks.Remove(book);

                Console.WriteLine($"\n{Name} returned: {book.title}\n");
                return true;
            }
            return false;
        }




    }
}
