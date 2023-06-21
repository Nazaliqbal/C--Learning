using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Book
    //using constructor
    {
        public string book;
        public string author;
        public int pages;

        public Book(string book, string author, int pages)
        {
            this.book = book;
            this.author = author;
            this.pages = pages;
        }
        public static void BookCall()
        {
            Console.WriteLine("Bookcall method from book class is called");
        }
    }
}
