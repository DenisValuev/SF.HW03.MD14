using SF.HW03.MD14.Models;

namespace SF.HW03.MD14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000014, "innokentii@example.com"));
            phoneBook.Add(new Contact("Гоша", "Куценко", 799900000015, "gosha@example.com"));
            phoneBook.Add(new Contact("Гоша", "Некуценко", 799900000016, "ne-gosha@example.com"));

            var sortedPhoneBook = phoneBook
                .OrderBy(c => c.Name)
                .ThenBy(c => c.LastName);

            Console.Write("Укажите количество контактов на странице: ");
            int countContactsInPage = int.Parse(Console.ReadLine());


            while (true)
            {
                //Количество контактов в телефонном справочнике
                int countContactsAll = phoneBook.Count();
                int maxPage = 0;
                if ((countContactsAll % countContactsInPage) != 0)
                {
                    maxPage = countContactsAll / countContactsInPage + 1;
                }
                else
                {
                    maxPage = countContactsAll / countContactsInPage;
                }

                Console.Write("\nВведите номер страницы: ");
                var keyChar = Console.ReadKey().KeyChar;

                Console.WriteLine();

                //Проверяем, число ли это
                var parsed = Int32.TryParse(keyChar.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > maxPage)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страница не существует");
                }
                else
                {
                    var pageContent = sortedPhoneBook.Skip((pageNumber - 1) * countContactsInPage).Take(countContactsInPage);

                    foreach (var contact in pageContent)
                        Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber);
                }
            }
        }
    }
}
