using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Book : Media
    {
        public int Pages { get; set; }
        public string Genre { get; set; }
        public Book(string title, string author, int yearPublished, int pages, string genre)
            : base(title, author, yearPublished)
        {
            Pages = pages;
            Genre = genre;
        }

        public override string ToString() =>
            $"Book: {Title}, Author: {Author}, Year: {YearPublished}, Pages: {Pages}, Genre: {Genre}, Available: {IsAvailable}";
    }
}
