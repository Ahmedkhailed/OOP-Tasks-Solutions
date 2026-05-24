using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_oop.Properties
{
    public class Library
    {
        public string Name { get; }
        public List<Book> books { get; }
        public List<Member> members { get; }
        public List<BorrowingHistory> borrowingHistory { get; private set; }

        public Library(string name)
        {
            this.Name = name;
            this.books = new List<Book>();
            this.members = new List<Member>();
            this.borrowingHistory = new List<BorrowingHistory>();
        }

        public void addBook(Book book)
        {
            if (book == null)
                return;

            if (book.IsAssigned)
            {
                Console.WriteLine("this book assigned another library");
            }
            else
            {
                book.Assigned();
                books.Add(book);
            }
        }

        public void registerMember(Member member)
        {
            if (member == null)
                return;

            if (members.Contains(member))
            {
                Console.WriteLine("this member already register");
            }
            else
            {
                members.Add(member);
            }
        }

        public void lendBook(Member member, string isbn)
        {
            Book bookByIsbn = books.Find(x => x.isbn == isbn);

            if (bookByIsbn == null || member == null)
                return;

            if (!members.Contains(member))
                members.Add(member);

            if (member.borrowBook(bookByIsbn))
            {
                borrowingHistory.Add(new BorrowingHistory(member, bookByIsbn));
            }
        }

        public void receiveBook(Member member, string isbn)
        {
            Book bookByIsbn = books.Find(x => x.isbn == isbn);

            if (bookByIsbn == null || member == null)
                return;

            if (!members.Contains(member))
                members.Add(member);

            if (member.returnBook(bookByIsbn))
            {
                borrowingHistory.Find(x => x.Book.Equals(bookByIsbn) && x.ReturnDate == null).receiveBook();
            }
        }

        public void displayAvailableBooks()
        {
            Console.WriteLine("Available books in City Central Library:");
            foreach (var item in books)
            {
                if (item.isAvailable)
                    Console.WriteLine($"- {item.getInfo()}");
            }
        }

        public List<Book> SearchBooksByTitle(string title) => books.FindAll(x => x.title.Contains(title));

        public List<Book> SearchBooksByAuthor(string author) => books.FindAll(x => x.author.Contains(author));



    }
}