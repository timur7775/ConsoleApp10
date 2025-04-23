using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Library<T> : IMediaManager<T> where T : Media
    {
        private List<T> items = new();
        private Dictionary<string, T> dict = new();

        public void Add(T item)
        {
            if (dict.ContainsKey(item.Title))
                throw new InvalidOperationException($"Item with title \"{item.Title}\" already exists.");
            items.Add(item);
            dict[item.Title] = item;
        }

        public bool Remove(string title)
        {
            if (!dict.ContainsKey(title))
                throw new KeyNotFoundException($"Item with title \"{title}\" not found.");
            var item = dict[title];
            items.Remove(item);
            dict.Remove(title);
            return true;
        }

        public T FindByTitle(string title)
        {
            if (!dict.TryGetValue(title, out var item))
                throw new KeyNotFoundException($"Item with title \"{title}\" not found.");
            return item;
        }

        public IEnumerable<T> FilterByYear(int year)
        {
            return items.Where(i => i.YearPublished >= year);
        }

        public IEnumerable<T> GetAllAvailable()
        {
            return items.Where(i => i.IsAvailable);
        }

        public void Borrow(string title)
        {
            var item = FindByTitle(title);
            if (!item.IsAvailable)
                throw new InvalidOperationException($"Item \"{title}\" is currently not available.");
            item.IsAvailable = false;
        }

        public void Return(string title)
        {
            var item = FindByTitle(title);
            item.IsAvailable = true;
        }

        public void PrintAll()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Library is empty.");
                return;
            }
            foreach (var item in items)
                Console.WriteLine(item.ToString());
        }
    }
}
