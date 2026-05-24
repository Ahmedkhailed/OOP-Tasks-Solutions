using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_oop
{
    public class Book
    {
        public string title {  get;private set; }
        public string author { get;private set; }
        public string isbn { get;private set; }
        public bool isAvailable { get;private set; }
        public bool IsAssigned { get; private set; }


        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.isAvailable = true;
            this.IsAssigned = false;
        }

        public void Assigned()
        {
            IsAssigned = true;
        }

        public string getInfo()
        {
            return $"{title} by {author} (ISBN: {isbn})";
        }

        public bool borrow()
        {
            if (this.isAvailable)
            {
                isAvailable = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void returnBook()
        {
            if (isAvailable)
            {
                Console.WriteLine("this book not borrowed");
            }
            else
            {
                isAvailable = true;
            }
        }

    }
}
