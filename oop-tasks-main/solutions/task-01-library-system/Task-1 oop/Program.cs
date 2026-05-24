using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1_oop.Properties;

namespace Task_1_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a library
            Library library = new Library("City Central Library");

            // Create books
            Book book1 = new Book("Design Patterns", "Gang of Four", "978-0201633610");
            Book book2 = new Book("Clean Code", "Robert Martin", "978-0132350884");
            Book book3 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957059");
            Book book4 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957050");
            Book book5 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957054");

            // Add books to library
            library.addBook(book1);
            library.addBook(book2);
            library.addBook(book3);
            library.addBook(book4);
            library.addBook(book5);

            // Register members
            Member member1 = new Member("Alice Johnson", "M001");
            Member member2 = new Member("Bob Smith", "M002");

            library.registerMember(member1);
            library.registerMember(member2);

            // Display available books
            library.displayAvailableBooks();

            // Member borrows a book
            library.lendBook(member1, "978-0201633610");
            library.lendBook(member1, "978-0132350884");
            library.lendBook(member1, "978-0135957059");
            library.lendBook(member1, "978-0135957050");
            library.lendBook(member1, "978-0135957054");

            // Display available books again
            library.displayAvailableBooks();

            // Member returns a book
            library.receiveBook(member1, "978-0201633610");

            library.lendBook(member1, "978-0201633610");
            library.lendBook(member1, "978-0132350884");
            library.lendBook(member1, "978-0135957059");
            library.lendBook(member1, "978-0135957050");
            library.lendBook(member1, "978-0135957054");
            library.receiveBook(member1, "978-0132350884");
            library.receiveBook(member1, "978-0201633610");
            library.receiveBook(member1, "978-0135957059");
            library.receiveBook(member1, "978-0201633610");

            library.lendBook(member1, "978-0201633610");
            library.lendBook(member1, "978-0132350884");
            library.lendBook(member1, "978-0135957059");
            library.lendBook(member1, "978-0135957050");

            foreach (var item in library.borrowingHistory)
            {
                Console.WriteLine("___________________________");
                Console.WriteLine($"Member Name : {item.Member.Name}");
                Console.WriteLine($"Book Title  : {item.Book.title}");
                Console.WriteLine($"Borrowing date : {item.BorrowingDate.ToString()}");
                if (item.ReturnDate != null)
                    Console.WriteLine($"Reutrn Date : {item.ReturnDate}");
                else
                    Console.WriteLine($"Reutrn Date : ");

                Console.WriteLine("___________________________");
            }
        }
    }
}
