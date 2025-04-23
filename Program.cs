namespace ConsoleApp10
{
    class Program
    {
        static void Main()
        {
            var library = new Library<Media>();

            try
            {
                library.Add(new Book("1984", "George Orwell", 1949, 328, "Dystopian"));
                library.Add(new Movie("The Matrix", "Wachowski Brothers", 1999, 136, "Lana Wachowski"));
                library.Add(new MusicAlbum("Abbey Road", "The Beatles", 1969, "The Beatles", 17));

                Console.WriteLine("Все элементы в библиотеке:");
                library.PrintAll();

                Console.WriteLine("\nВыдаём фильм \"The Matrix\"...");
                library.Borrow("The Matrix");
                Console.WriteLine("Элемент доступен: " + library.FindByTitle("The Matrix").IsAvailable);

                Console.WriteLine("\nФильтруем медиа с 1950 года:");
                foreach (var item in library.FilterByYear(1950))
                    Console.WriteLine(item.ToString());

                Console.WriteLine("\nНедоступные элементы:");
                foreach (var item in library.FilterByYear(0).Where(i => !i.IsAvailable))
                    Console.WriteLine(item.ToString());

                Console.WriteLine("\nВозвращаем \"The Matrix\"...");
                library.Return("The Matrix");
                Console.WriteLine("Элемент доступен: " + library.FindByTitle("The Matrix").IsAvailable);

                Console.WriteLine("\nУдаляем книгу \"1984\"...");
                library.Remove("1984");
                library.PrintAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}
